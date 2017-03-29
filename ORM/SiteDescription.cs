using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class SiteDescription
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}