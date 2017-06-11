using System;
using Ninject.Modules;
using WoW_console.Contracts;
using WoW_console.Providers;
using WoW.CreateCommands.Contracts;
using WoW.CreateCommands;
using WoW_console.Controllers;

namespace WoW_console.Container
{
    public class WoWNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IEntityCreationFactory>().To<EntityCreationFactory>();
            this.Bind<IControllerFactory>().To<ControllerFactory>();

            this.Bind<ICreateEntity>().To<CreatePlanet>().Named("CreatePlanet");

            this.Bind<ICreationController>().To<CreatePlanetController>().Named("CreatePlanetController");
        }
    }
}
