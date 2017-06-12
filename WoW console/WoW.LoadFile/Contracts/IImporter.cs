using System.Collections.Generic;
using Database;

namespace WoW.LoadFile.Contracts
{
    public interface IImporter
    {
        IEnumerable<Characters> DeserializeJSON();

        IEnumerable<Characters> DeserializeXML();

    }
}