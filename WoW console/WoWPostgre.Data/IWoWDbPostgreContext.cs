using System.Data.Entity;
using WoW_Postgre.Models;

namespace WoWPostgre.Data
{
    public interface IWoWDbPostgreContext
    {
        IDbSet<Users> Users { get; set; }

        IDbSet<Characters> Characters { get; set; }

        IDbSet<Countries> Countries { get; set; }

        IDbSet<Cities> Cities { get; set; }

        int SaveChanges();
    }
}
