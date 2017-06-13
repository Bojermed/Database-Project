using Database;
using System;
using System.Linq;
using WoW.CreateCommands;
using WoWPostgreData;
using WoW_Postgre.Data;
using Ninject;
using WoW_console.Container;
using WoW_console.Contracts;
using WoW.Exports;
using WoW.LoadFile;
using System.Collections.Generic;

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