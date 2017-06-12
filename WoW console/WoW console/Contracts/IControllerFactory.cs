using WoW.Exports;
using WoW.LoadFile;

namespace WoW_console.Contracts
{
    public interface IControllerFactory
    {
        ICreationController GetController(string controllerName);

        IInformational GetInformationalController(string controllerName);

        IRegisterController GetRegistrationController();

        ILoginController GetLoginController();

        IImporter ImportFiles();

        IPdfExporter ExportFiles();
    }
}