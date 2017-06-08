using System.Data.Entity;
using Database;

namespace WoW_console
{
    public interface IWoWDbContext
    {
        IDbSet<Characters> Characters { get; set; }

        IDbSet<Classes> Classes { get; set; }

        IDbSet<Continents> Continents { get; set; }

        IDbSet<Factions> Factions { get; set; }

        IDbSet<Genders> Genders { get; set; }

        IDbSet<Npcs> Npcs { get; set; }

        IDbSet<Planets> Planets { get; set; }

        IDbSet<Players> Players { get; set; }

        IDbSet<Professions> Professions { get; set; }

        IDbSet<Races> Races { get; set; }

        IDbSet<Resources> Resources { get; set; }

        IDbSet<Statuses> Statuses { get; set; }

        IDbSet<Zones> Zones { get; set; }

        int SaveChanges();
    }
}