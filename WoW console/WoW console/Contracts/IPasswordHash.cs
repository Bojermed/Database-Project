namespace WoW_console.Contracts
{
    public interface IPasswordHash
    {
        string Hash(string username, string password);
    }
}