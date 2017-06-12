namespace WoW_console.Contracts
{
    public interface IInformational
    {
        IWriter Writer { get; }

        void StateMessage();
    }
}