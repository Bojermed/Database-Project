namespace WoW.Exports.Contracts
{
    public interface IPdfExporter
    {
        void CreatePDFReport(string path);
    }
}