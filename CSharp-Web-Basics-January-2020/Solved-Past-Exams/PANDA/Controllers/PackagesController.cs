using PANDA.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace PANDA.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;

        public PackagesController(IPackagesService packagesService)
        {
            this.packagesService = packagesService;
        }

        public HttpResponse Details()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
    }
}
