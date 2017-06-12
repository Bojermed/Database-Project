namespace WoW_console.Contracts
{
    public interface IListCharactersController
    {
        IWoWDbContext DbContext { get; }

        IReader Reader { get; }

        IWriter Writer { get; }

        void ListCharacters(string username);
    }
}