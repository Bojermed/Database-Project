using System;
using WoW_console.Contracts;

namespace WoW_console.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
