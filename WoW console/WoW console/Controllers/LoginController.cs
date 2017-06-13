using WoW_console.Contracts;
using System.Linq;
using System;
using System.Drawing;

namespace WoW_console.Controllers
{
    public class LoginController : ILoginController
    {
        private const string USERNAME_PROMPT = "Enter your username:";
        private const string PASSWORD_PROMPT = "Enter your password:";
        private const string SUCCESSEFUL_LOGIN = "{0}, you have loged in successfully!";
        private const string INCORRECT_PASSWORD = "Password is incorrect. Please try again...";
        private const string USER_NOT_FOUND = "Username was not found. Please try again...";

        private readonly IWoWDbContext dbContext;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IPasswordHash hasher;

        public LoginController(IWoWDbContext dbContext, IReader reader, IWriter writer, IPasswordHash hasher)
        {
            this.dbContext = dbContext;
            this.reader = reader;
            this.writer = writer;
            this.hasher = hasher;
        }

        public IWoWDbContext DbContext
        {
            get
            {
                return this.dbContext;
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

        public string Login()
        {
            this.Writer.Clear();
            this.Writer.WriteLineInfo(USERNAME_PROMPT);
            var username = this.Reader.ReadLine();
            this.Writer.WriteLineInfo(PASSWORD_PROMPT);
            var password = this.Reader.ReadLinePassword();
            var hashedPassword = this.Hasher.Hash(username, password);

            var dbPassword = "";
            try
            {
                dbPassword = this.DbContext.Players.Where(p => p.Username == username).FirstOrDefault().PasswordHash;                
            }
            catch(Exception ex)
            {
                this.Writer.WriteLineError(USER_NOT_FOUND);
                return "";
            }

            if(hashedPassword == dbPassword)
            {
                this.Writer.WriteLineSuccess(string.Format(SUCCESSEFUL_LOGIN, username));
                return username;
            }
            else
            {
                this.Writer.WriteLineError(INCORRECT_PASSWORD);
                return "";
            }
        }
    }
}
