using System.Collections.Generic;
using WoW.CreateCommands.Contracts;

namespace WoW_console.Contracts
{
    public interface IRegisterController
    {
        IList<string> EntityCharacteristics { get; }

        IPasswordHash Hasher { get; }

        ICreateEntity PlayerCreator { get; }

        IReader Reader { get; }

        IWriter Writer { get; }

        string RegisterUser();
    }
}