namespace SoftUni.WebServer.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using ActionResults;
    using Interfaces;
    using Models;
    using Security;
    using SoftUni.WebServer.Http.Interfaces;
    using SoftUni.WebServer.Http.Session;
    using Validation;
    using Views;

    public abstract class Controller
    {
        protected Controller()
        {
            this.ViewData = new ViewData();
            this.User = new Authentication();
        }

        public ViewData ViewData { get; protected set; }

        public Authentication User { get; set; }

        public IHttpRequest Request { get; set; }

        public ParameterValidator ParameterValidator { get; set; }

        #region Lifecycle methods
        public virtual void OnControllerCreated()
        {
        }

        public virtual void OnAuthentication()
        {
        }

        public virtual void OnActionExecuting(MethodInfo action)
        {
        }

        public virtual void OnActionExecuted(MethodInfo action, string invocationResult)
        {
        }
        #endregion

        protected internal void SetAuthentication()
        {
            int? userId = this.Request.Session.Get<int?>(SessionStore.SessionUserIdKey);
            string username = this.Request.Session.Get<string>(SessionStore.SessionUsernameKey);
            IEnumerable<string> roles = this.Request.Session.Get<IEnumerable<string>>(SessionStore.SessionUserRolesKey);
            if (roles == null)
            {
                roles = new string[0];
            }

            if (userId.HasValue && username != null)
            {
                this.User = new Authentication(userId.Value, username, roles);
            }
            else
            {
                this.User = new Authentication();
            }
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            var controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Get.ControllerSuffix, string.Empty);

            var fullyQualifiedName = string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

            var view = new View(this.ViewData.Data, fullyQualifiedName);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected bool IsValidModel(object bindingModel)
        {
            var properties = bindingModel.GetType().GetProperties();

            bool errorFound = false;

            foreach (var property in properties)
            {
                var validationAttributes = property
                    .GetCustomAttributes(true)
                    .Where(ca => ca is ValidationAttribute)
                    .Cast<ValidationAttribute>();

                if (!validationAttributes.Any())
                {
                    continue;
                }

                foreach (var validationAttribute in validationAttributes)
                {
                    object propertyValue = property.GetValue(bindingModel);
                    var validationResult = validationAttribute.GetValidationResult(propertyValue, new ValidationContext(bindingModel));
                    if (validationResult != ValidationResult.Success)
                    {
                        this.ParameterValidator.AddModelError(
                            property.Name,
                            validationResult.ErrorMessage.Replace(bindingModel.GetType().Name, property.Name));
                        errorFound = true;
                    }
                }
            }

            return !errorFound;
        }

        protected string GetValidationSummary(string listCssClass = "")
        {
            var errors = this.ParameterValidator.ModelErrors
                .SelectMany(error => error.Value)
                .Select(errorMsg => $"<li>{errorMsg}</li>");
            return $@"<ul class=""{listCssClass}"">{string.Join(Environment.NewLine, errors)}</ul>";
        }

        protected void SignIn(string username, int userId, IEnumerable<string> roles)
        {
            this.Request.Session.Add(SessionStore.SessionUserIdKey, userId);
            this.Request.Session.Add(SessionStore.SessionUsernameKey, username);
            this.Request.Session.Add(SessionStore.SessionUserRolesKey, roles);
            this.SetAuthentication();
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }
    }
}
