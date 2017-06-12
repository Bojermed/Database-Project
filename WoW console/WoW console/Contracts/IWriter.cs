using System.Drawing;

namespace WoW_console.Contracts
{
    public interface IWriter
    {
        void WriteLine(string message);

        void WriteLineSuccess(string message);

        void WriteLineError(string message);

        void WriteLineInfo(string message);
    }
}