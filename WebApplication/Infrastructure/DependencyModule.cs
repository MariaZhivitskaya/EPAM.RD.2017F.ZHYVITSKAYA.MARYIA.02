using BLL.Interface.Services;
using BLL.Services;
using Ninject.Modules;

namespace WebApplication.Infrastructure
{
    public class DependencyModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IImageService>().To<ImageService>();
            Bind<IAlbumService>().To<AlbumService>();
        }
    }
}