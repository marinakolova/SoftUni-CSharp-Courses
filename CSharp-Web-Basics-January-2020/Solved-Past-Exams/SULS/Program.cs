using SIS.MvcFramework;
using System.Threading.Tasks;

namespace SULS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
