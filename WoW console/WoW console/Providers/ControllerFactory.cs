using Ninject;
using WoW.Exports.Contracts;
using WoW.LoadFile.Contracts;
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

        public IInformational GetInformationalController(string controllerName)
        {
            return this.kernel.Get<IInformational>(controllerName);
        }

        public IRegisterController GetRegistrationController()
        {
            return this.kernel.Get<IRegisterController>();
        }

        public ILoginController GetLoginController()
        {
            return this.kernel.Get<ILoginController>();
        }

        public IImporter ImportFiles()
        {
            return this.kernel.Get<IImporter>();
        }

        public IPdfExporter ExportFiles()
        {
            return this.kernel.Get<IPdfExporter>();
        }
    }
}
