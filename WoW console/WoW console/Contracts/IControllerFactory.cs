using WoW_console.Contracts;

namespace WoW_console.Contracts
{
    public interface IControllerFactory
    {
        ICreationController GetController(string controllerName);
    }
}