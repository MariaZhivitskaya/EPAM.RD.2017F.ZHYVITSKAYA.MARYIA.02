using System;

namespace BLL.Interface.Entities
{
    public class ImageEntity
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