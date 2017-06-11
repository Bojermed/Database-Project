using WoW_console.Contracts;
using System.Linq;

namespace WoW_console.Controllers
{
    public class LoginController : ILoginController
    {
        private const string USERNAME_PROMPT = "Enter your username:";
        private const string PASSWORD_PROMPT = "Enter your password:";
        private const string SUCCESSEFUL_LOGIN = "{0}, you have loged in successfully!";
        private const string FAILED_LOGIN = "Username or password is wrong. Please try again...";

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
            this.Writer.WriteLine(USERNAME_PROMPT);
            var username = this.Reader.ReadLine();
            this.Writer.WriteLine(PASSWORD_PROMPT);
            var password = this.Reader.ReadLine();
            var hashedPassword = this.Hasher.Hash(username, password);

            var dbPassword = this.DbContext.Players.Where(p => p.Username == username).FirstOrDefault().PasswordHash;

            if(hashedPassword == dbPassword)
            {
                this.Writer.WriteLine(string.Format(SUCCESSEFUL_LOGIN, username));
                return username;
            }
            else
            {
                this.Writer.WriteLine(FAILED_LOGIN);
                return "";
            }
        }
    }
}
