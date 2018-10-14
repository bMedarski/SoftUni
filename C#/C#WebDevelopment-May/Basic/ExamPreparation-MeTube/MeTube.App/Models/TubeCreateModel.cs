namespace MeTube.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TubeCreateModel
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        public string Author { get; set; }

      
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string VideoId { get; set; }

        ////[Required]
        //public int UploaderId { get; set; }
    }
}
