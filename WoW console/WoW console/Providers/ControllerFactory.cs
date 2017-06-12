﻿using Ninject;
using WoW_console.Contracts;
using WoW_console.Controllers;

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

        public IListCharactersController GetListCharacterController()
        {
            return this.kernel.Get<IListCharactersController>();
        }
    }
}
