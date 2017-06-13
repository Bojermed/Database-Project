using Ninject;
using WoW_console.Container;

namespace WoW_console
{
    public class Startup
    {
        static void Main()
        {
            var kernel = new StandardKernel(new WoWNinjectModule());
            var engine = kernel.Get<Engine>();
            engine.Start();     
        }
    }
}