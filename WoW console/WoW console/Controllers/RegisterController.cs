using System;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console.Contracts;

namespace WoW_console.Controllers
{
    public class RegisterController : IRegisterController
    {
        private const string FAILIURE_REGISTRATION = "Registration was unsuccesseful. Please try again...";
        private const string SUCCESSEFUL_REGISTRATION = "{0}, your registration was successeful!";
        private const string USERNAME_PROMPT = "Select your username:";
        private const string PASSWORD_PROMPT = "Select your password:";
        private const string DEFAULT_SERVER = "0";

        private readonly ICreateEntity playerCreator;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IPasswordHash hasher;

        private readonly IList<string> entityCharacteristics;

        public RegisterController(ICreateEntity playerCreator, IReader reader, IWriter writer,IPasswordHash hasher)
        {
            this.playerCreator = playerCreator;
            this.reader = reader;
            this.writer = writer;
            this.hasher = hasher;
            this.entityCharacteristics = new List<string>();
        }

        public ICreateEntity PlayerCreator
        {
            get
            {
                return this.playerCreator;
            }
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }
        }

        public IPasswordHash Hasher
        {
            get
            {
                return this.hasher;
            }
        }

        public IList<string> EntityCharacteristics
        {
            get
            {
                return this.entityCharacteristics;
            }
        }

        public string RegisterUser()
        {
            // check if username is unique
            this.Writer.WriteLine(USERNAME_PROMPT);
            string username = this.Reader.ReadLine();
            this.Writer.WriteLine(PASSWORD_PROMPT);
            string password = this.Reader.ReadLine();
            
            var hashedPassword = Hasher.Hash(username, password);

            this.EntityCharacteristics.Add(username);
            this.EntityCharacteristics.Add(hashedPassword);
            this.EntityCharacteristics.Add(DEFAULT_SERVER);
            
            try
            {
                this.PlayerCreator.CreateEntity(this.EntityCharacteristics);
                this.Writer.WriteLine(string.Format(SUCCESSEFUL_REGISTRATION, username));
                return username;
            }
            catch (Exception ex)
            {
                this.Writer.WriteLine(FAILIURE_REGISTRATION);
                return "";
            }
        }
    }
}
