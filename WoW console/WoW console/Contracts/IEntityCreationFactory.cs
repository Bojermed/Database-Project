using WoW.CreateCommands.Contracts;

namespace WoW_console.Contracts
{
    public interface IEntityCreationFactory
    {
        ICreateEntity GetEntityCreator();
    }
}