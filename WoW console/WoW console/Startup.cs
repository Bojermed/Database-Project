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

            //var dbContext = new WoWDbContext();
            //var importer = new Importer(dbContext);
            //importer.ResourcesDeserializeJSON();
            ////importer.ProfessionsDeserializeJSON();
            ////importer.FactionsDeserializeJSON();
            ////importer.RacesDeserializeJSON();
            //importer.ClassesDeserializeJSON();
            //importer.ConnectRacesClassesDeserializeJSON();
            //var classRaces = new List<Races>();
            //var newRace = new Races()
            //{
            //    Name = "Izvanzemno"
            //};
            //classRaces.Add(newRace);

            //var newClass = new Classes()
            //{
            //    Name = "Stefan",
            //    ResourceId = 1,
            //    Lore = "Rodil se bil",
            //    //Races = classRaces
            //};
            //dbContext.Classes.Add(newClass);
            //dbContext.SaveChanges();

            //var dbContext = new WoWDbContext();
            //var importer = new Importer(dbContext);
            //importer.ResourcesDeserializeJSON();
            //var classCreator = new CreateClass(dbContext);
            //var param = new List<string>()
            //{
            //    "Stefan",
            //    "1",
            //    "istoriq"
            //};
            //classCreator.CreateEntity(param);
        }

        //public static void GetPDFReport()
        //{
        //    var context = new WoWDbContext();

        //    var pdf = new PdfExporter(context);
        //    pdf.CreatePDFReport("..\\..\\Pdf-Reports");
        //}

        //public static void ImportOldData()
        //{
        //    var contextImport = new WoWDbContext();

        //    var import = new Importer(contextImport);
        //    import.ReadFiles();
        //    import.DeserializeJSON();

        //    contextImport.SaveChanges();
        //}
    }
}