namespace MeTube.App.Helpers
{
    using Models;
    using Services;

    public static class HtmlHelpers
    {
        public static string ToHtml(this TubeViewModel tube)
            => $@"
                <div class=""card col-3 thumbnail text-center"">
                    <a href=""/tubes/details?id={tube.Id}"" target=""_self""> 
                    <img class=""card-image-top img-fluid img-thumbnail"" width=""400"" 
                    src=""https://img.youtube.com/vi/{tube.VideoId}/0.jpg"" border=""0"" />
                    </a>
                   
                    <div class=""card-body"">
                        <h3 class=""card-title text-center""><strong>{tube.Title.Shortify(30)}</strong></h3>
                        <h4 class=""card-text text-center""><em>{tube.Author}</em></h4>
                       </br>
                    </div>
                </div>";
    }
}
