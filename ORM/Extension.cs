using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Extension
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}