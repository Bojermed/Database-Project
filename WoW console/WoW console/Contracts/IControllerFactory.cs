using WoW.Exports;
using WoW.Exports.Contracts;
using WoW.LoadFile.Contracts;

namespace WoW_console.Contracts
{
    public interface IControllerFactory
    {
        ICreationController GetController(string controllerName);

        IInformational GetInformationalController(string controllerName);

        IRegisterController GetRegistrationController();

        ILoginController GetLoginController();

        IListCharactersController GetListCharactersController();

        IImporter ImportFiles();

        IPdfExporter ExportFiles();
    }
}