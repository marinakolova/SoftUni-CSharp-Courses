using Microsoft.EntityFrameworkCore;
using PANDA.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Collections.Generic;

namespace PANDA
{
    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IPackagesService, PackagesService>();
            serviceCollection.Add<IReceiptsService, ReceiptsService>();
        }
    }
}
