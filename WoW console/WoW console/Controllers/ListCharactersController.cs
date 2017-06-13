using System.Linq;
using WoW_console.Contracts;

namespace WoW_console.Controllers
{
    public class ListCharactersController : IListCharactersController
    {
        private readonly IWoWDbContext dbContext;
        private readonly IReader reader;
        private readonly IWriter writer;

        public ListCharactersController(IWoWDbContext dbContext, IReader reader, IWriter writer)
        {
            this.dbContext = dbContext;
            this.reader = reader;
            this.writer = writer;
        }

        public IWoWDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }
        }


        public void ListCharacters(string username)
        {
            var playerId = this.DbContext.Players.Where(p => p.Username == username).FirstOrDefault().Id;

            var characters = this.DbContext.Characters
                .Where(c => c.PlayerId == playerId)
                .Join(this.DbContext.Factions,
                    c => c.FactionId,
                    f => f.Id,
                    (c, f) => new { character = c, faction = f })
                .Join(this.DbContext.Races,
                    cf => cf.character.RaceId,
                    r => r.Id,
                    (cf, r) => new { charFac = cf, race = r })
                .Join(this.DbContext.Classes,
                    cfr => cfr.charFac.character.ClassId,
                    cl => cl.Id,
                    (cfr, cl) => new { charFacRace = cfr, clas = cl })
                .Join(this.DbContext.Professions,
                    cfrcl => cfrcl.charFacRace.charFac.character.ProfessionId,
                    p => p.Id,
                    (cfrcl, p) => new { charFacRaceClass = cfrcl, profession = p })
                .ToList();

            foreach (var chara in characters)
            {
                this.Writer.Clear();
                this.Writer.WriteLine("Name: " + chara.charFacRaceClass.charFacRace.charFac.character.Name);
                this.Writer.WriteLine("Faction: " + chara.charFacRaceClass.charFacRace.charFac.faction.Name);
                this.Writer.WriteLine("Race: " + chara.charFacRaceClass.charFacRace.race.Name);
                this.Writer.WriteLine("Class: " + chara.charFacRaceClass.clas.Name);
                this.Writer.WriteLine("Profession: " + chara.profession.Name);
                this.Writer.WriteLineInfo("-----------------");
            }
        }
    }
}
