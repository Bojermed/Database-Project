using System.Collections.Generic;
using WoW.CreateCommands;
using WoW.CreateCommands.Contracts;

namespace WoW_console.Contracts
{
    public interface ICreationController
    {
        IList<string> EntityCharacteristics { get; set; }

        ICreateEntity EntityCreator { get; }

        IReader Reader { get; }

        IWriter Writer { get; set; }

        void GuideUser();
    }
}