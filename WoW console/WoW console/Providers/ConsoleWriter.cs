using System;
using WoW_console.Contracts;

namespace WoW_console.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
