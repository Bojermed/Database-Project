using Database;
using System.Data.Entity;

namespace WoW_console
{
    public class WoWDbContext : DbContext, IWoWDbContext
    {
        public WoWDbContext() 
            : base("WoWDb")
        {

        }

        public virtual IDbSet<Characters> Characters { get; set; }

        public virtual IDbSet<Classes> Classes { get; set; }

        public virtual IDbSet<Continents> Continents { get; set; }

        public virtual IDbSet<Factions> Factions { get; set; }

        public virtual IDbSet<Genders> Genders { get; set; }

        public virtual IDbSet<Npcs> Npcs { get; set; }

        public virtual IDbSet<Planets> Planets { get; set; }

        public virtual IDbSet<Players> Players { get; set; }

        public virtual IDbSet<Professions> Professions { get; set; }

        //public virtual IDbSet<ProfessionTypes> ProfessionTypes { get; set; }

        public virtual IDbSet<Races> Races { get; set; }

        public virtual IDbSet<Resources> Resources { get; set; }

       //public virtual IDbSet<Server> Server { get; set; }

        public virtual IDbSet<Statuses> Statuses { get; set; }

        public virtual IDbSet<Zones> Zones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Races>().Property(p => p.FactionId).IsOptional();

            base.OnModelCreating(modelBuilder);
        }

    }
}
