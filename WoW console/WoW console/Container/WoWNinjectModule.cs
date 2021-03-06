﻿using System;
using Ninject.Modules;
using WoW_console.Contracts;
using WoW_console.Providers;
using WoW.CreateCommands.Contracts;
using WoW.CreateCommands;
using WoW_console.Controllers;
using WoW.LoadFile;
using WoW.LoadFile.Contracts;
using WoW.Exports.Contracts;
using WoW.Exports;

namespace WoW_console.Container
{
    public class WoWNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IEngine>().To<Engine>();
            this.Bind<IEntityCreationFactory>().To<EntityCreationFactory>();
            this.Bind<IControllerFactory>().To<ControllerFactory>();
            this.Bind<IWoWDbContext>().To<WoWDbContext>();
            this.Bind<IPasswordHash>().To<PasswordHash>();

            this.Bind<IInformational>().To<HomeController>().Named("HomeController");
            this.Bind<IInformational>().To<HelpController>().Named("HelpController");
            this.Bind<IRegisterController>().To<RegisterController>();
            this.Bind<ILoginController>().To<LoginController>();
            this.Bind<IListCharactersController>().To<ListCharactersController>();

            this.Bind<ICreateEntity>().To<CreatePlanet>().WhenInjectedExactlyInto<CreatePlanetController>();
            this.Bind<ICreateEntity>().To<CreatePlayer>().WhenInjectedExactlyInto<RegisterController>();
            this.Bind<ICreateEntity>().To<CreateCharacter>().WhenInjectedExactlyInto<CreateCharacterController>();

            this.Bind<IImporter>().To<Importer>();
            this.Bind<IZipReader>().To<ZipReader>();
            this.Bind<IPdfExporter>().To<PdfExporter>();

            this.Bind<ICreationController>().To<CreatePlanetController>().Named("CreatePlanetController");
            this.Bind<ICreationController>().To<CreateCharacterController>().Named("CreateCharacterController");

        }
    }
}
