using System.Data.Entity;
using WoWPostgreData;
using WoW_Postgre.Models;

namespace WoW_Postgre.Data
{
    public class WoWDbPostgreContext : DbContext,IWoWDbPostgreContext
    {
        public WoWDbPostgreContext()
            : base("PostgreWoWDb")
        {

        }
        public virtual IDbSet<Users> Users { get; set; }

        public virtual IDbSet<Characters> Characters { get; set; }

        public virtual IDbSet<Countries> Countries { get; set; }

        public virtual IDbSet<Cities> Cities { get; set; }
    }
}
