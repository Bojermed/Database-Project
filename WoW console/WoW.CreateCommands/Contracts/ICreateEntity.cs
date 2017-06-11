using System.Collections.Generic;
using WoW_console;

namespace WoW.CreateCommands.Contracts
{
    public interface ICreateEntity
    {
        IWoWDbContext DbContext { get; }

        void CreateEntity(IList<string> entityCharacteristics);
    }
}