using System.Collections.Generic;
using Database;

namespace WoW.LoadFile
{
    public interface IImporter
    {
        IEnumerable<Characters> DeserializeJSON();

        IEnumerable<Characters> DeserializeXML();

    }
}