using WoW_console.Contracts;

namespace WoW_console.Contracts
{
    public interface IControllerFactory
    {
        ICreationController GetController(string controllerName);

        IInformational GetInformationalController(string controllerName);

        IRegisterController GetRegistrationController();

        ILoginController GetLoginController();
    }
}