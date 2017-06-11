namespace WoW_console.Contracts
{
    public interface ILoginController
    {
        IWoWDbContext DbContext { get; }

        IPasswordHash Hasher { get; }

        IReader Reader { get; }

        IWriter Writer { get; }

        string Login();
    }
}