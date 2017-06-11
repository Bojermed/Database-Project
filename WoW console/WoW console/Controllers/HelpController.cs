﻿using WoW_console.Contracts;

namespace WoW_console.Controllers
{
    public class HelpController : IInformational
    {
        private const string COMMANDS_SUMMARY = @"
--Exit - terminates the program
--Register - creates a user account
--Login - access your account
--Logout - leave your account
--Create [Entity] - creates an entity of specified type.
Allowed enities:
Character
Example use: ""--Create Character""
";
        private readonly IWriter writer;

        public HelpController(IWriter writer)
        {
            this.writer = writer;
        }

        public IWriter Writer
        {
            get { return this.writer; }
        }

        public void StateMessage()
        {
            this.Writer.WriteLine(COMMANDS_SUMMARY);
        }
    }
}
