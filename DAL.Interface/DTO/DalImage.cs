using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalImage : IEntity
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int ExtensionId { get; set; }
    }
}
