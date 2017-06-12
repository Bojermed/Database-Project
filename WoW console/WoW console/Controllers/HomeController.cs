using WoW_console.Contracts;

namespace WoW_console.Controllers
{
    public class HomeController : IInformational
    {
        private const string WELCOME_HEADER = @"
           WELCOME TO
#################################
##                             ##
##   -- Heroes of Azeroth --   ##
##                             ##
#################################

Well met, CHAMPION!
Create your account, 
fill it with new characters 
and do battle on the fields of
AZEROTH.           
            ";

        private const string COMMAND_INSTRUCTIONS = @"--------------
Enther command
--Login
--Register
--Help
--Exit
to access and create an account, view all commands
or terminate the program.
--------------";

        private readonly IWriter writer;

        public HomeController(IWriter writer)
        {
            this.writer = writer;
        }

        public IWriter Writer
        {
            get { return this.writer; }
        }

        public void StateMessage()
        {
            this.Writer.WriteLine(WELCOME_HEADER);
            this.Writer.WriteLine(COMMAND_INSTRUCTIONS);
        }
    }
}
