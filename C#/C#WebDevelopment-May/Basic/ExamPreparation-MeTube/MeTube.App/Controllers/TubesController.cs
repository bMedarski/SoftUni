namespace MeTube.App.Controllers
{
    using System.Linq;
    using Helpers;
    using Models;
    using Services;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class TubesController : BaseController
    {
        public const string CreateNoteErrorMessage = @"<p>Check your form for errors.</p><p>Author's name must be 3 symbols minimum.</p><p>Title must be 3 symbols minimum.</p><p>YouTube link must be valid YouTube URL.</p>";

        private readonly UsersService users;
        private readonly TubesService tubes;

        public TubesController()
        {
            this.users = new UsersService();
            this.tubes = new TubesService();
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            this.GetUserIdForNavBar();

            this.Model.Data["username"] = this.User.Name;
            return View();
        }


        [HttpPost]
        public IActionResult Add(TubeCreateModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                RedirectToLogin();
            }

            this.GetUserIdForNavBar();

            if (!this.IsValidModel(model))
            {
                ShowError(CreateNoteErrorMessage);
                return View();
            }

            string youTubeId = GetYouTubeIdFromLink(model.VideoId);
            if (youTubeId == null)
            {
                ShowError(CreateNoteErrorMessage);
                return View();
            }

            var username = this.User.Name;
            var tubeId = this.tubes.Add(model.Title.CapitalizeFirstLetter(), model.Author, model.Description, youTubeId, username);

            if (tubeId == default(int))
            {
                ShowError(CreateNoteErrorMessage);
                return View();
            }

            return this.RedirectToAction($"/tubes/details?id={tubeId}");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            this.tubes.IncrementViewsByOne(id);
            var tube = this.tubes.GetById(id);

            this.GetUserIdForNavBar();

            this.Model.Data["title"] = tube.Title;
            this.Model.Data["author"] = tube.Author;
            this.Model.Data["description"] = tube.Description;
            this.Model.Data["videoid"] = tube.VideoId;
            this.Model.Data["views"] = tube.Views.ToString();
            return View();
        }

        private static string GetYouTubeIdFromLink(string youTubeLink)
        {
            string youTubeId = null;
            if (youTubeLink.Contains("youtube.com"))
            {
                youTubeId = youTubeLink.Split("?v=")[1];
            }
            else if (youTubeLink.Contains("youtu.be"))
            {
                youTubeId = youTubeLink.Split("/").Last();
            }

            return youTubeId;
        }
    }
}
