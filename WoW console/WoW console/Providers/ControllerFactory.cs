using Ninject;
using WoW.CreateCommands.Contracts;
using WoW_console.Contracts;

namespace WoW_console.Providers
{
    public class ControllerFactory : IControllerFactory
    {
        private readonly IKernel kernel;

        public ControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICreationController GetController(string controllerName)
        {
            return this.kernel.Get<ICreationController>(controllerName);
        }
    }
}
