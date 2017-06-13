using System.Collections.Generic;
using Database;

namespace WoW.LoadFile.Contracts
{
    public interface IImporter
    {
        void SeedDatabase();
    }
}