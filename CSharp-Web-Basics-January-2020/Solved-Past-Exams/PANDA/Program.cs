using SIS.MvcFramework;
using System.Threading.Tasks;

namespace PANDA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
