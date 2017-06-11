namespace WoW_console.Contracts
{
    public interface IEngine
    {
        IReader Reader { get; }
        IWriter Writer { get; }

        void Start();
    }
}