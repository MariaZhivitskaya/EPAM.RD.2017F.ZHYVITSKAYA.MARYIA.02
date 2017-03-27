using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public byte[] Picture { get; set; }

        [Required]
        public int AlbumId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public int ExtensionId { get; set; }
    }
}
