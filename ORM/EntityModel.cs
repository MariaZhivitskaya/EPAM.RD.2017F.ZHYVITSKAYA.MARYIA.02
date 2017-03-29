using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class EntityModel : DbContext
    {
        public EntityModel() : base("name=EntityModel") { }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Album> Likes { get; set; }
        public virtual DbSet<Extension> Extensions { get; set; }
        public virtual DbSet<SiteDescription> SiteDescriptions { get; set; }
    }
}
