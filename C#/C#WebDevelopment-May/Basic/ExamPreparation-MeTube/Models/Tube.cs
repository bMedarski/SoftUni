namespace SimpleMvc.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tube
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        
        public string Description { get; set; }

        [Required]
        public string VideoId { get; set; }

        [Required]
        public int UploaderId { get; set; }

        public User Uploader { get; set; }

        public int Views { get; set; }
    }
}