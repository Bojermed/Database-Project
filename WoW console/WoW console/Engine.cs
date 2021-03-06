﻿using WoW_console.Contracts;

namespace WoW_console
{
    public class Engine : IEngine
    {
        private const string PROMPT_USER = "You can enter a new command:";
        private const string PROGRAM_TERMINATED = "Program has been terminated.";
        private const string WRONG_COMMAND = "You have entered an invalid command, please try again...";
        private const string SUCCESSEFUL_LOGIN = "You are now logged in!";
        private const string LOGOUT_MESSAGE = "You are now logged out!";
        private const string LOGEDIN_STATUS = "You are logged in as {0}.";
        private const string LOGEDOUT_STATUS = "You are not logged in yet.";
        private const string LOGOUT_TO_REGISTER = "You must log out before registering a new player.";
        private const string EXPORT_PATH = "..\\..\\..\\Pdf-Reports";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IControllerFactory controllerFactory;
        private readonly IWoWDbContext dbContext;

        private bool loggedIn;
        private string currentUsername;

        public Engine(IReader reader, IWriter writer, IControllerFactory controllerFactory, IWoWDbContext dbContext)
        {
            this.reader = reader;
            this.writer = writer;
            this.controllerFactory = controllerFactory;
            this.dbContext = dbContext;

            this.LoggedIn = false;
            this.CurrentUsername = "";
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

        public IControllerFactory ControllerFactory
        {
            get
            {
                return this.controllerFactory;
            }
        }

        public IWoWDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        public bool LoggedIn
        {
            get
            {
                return this.loggedIn;
            }

            set
            {
                this.loggedIn = value;
            }
        }

        public string CurrentUsername
        {
            get
            {
                return this.currentUsername;
            }

            set
            {
                this.currentUsername = value;
            }
        }

        public void Start()
        {
            var fileImporter = this.ControllerFactory.ImportFiles();
            fileImporter.SeedDatabase();

            var homeController = this.ControllerFactory.GetInformationalController("HomeController");
            homeController.StateMessage();

            while(true)
            {
                this.Writer.WriteLine("");
                this.Writer.WriteLineInfo(PROMPT_USER);
                var userInput = this.reader.ReadLine().ToLower().Split(' ');

                if(userInput[0] == "--exit")
                {
                    this.Writer.WriteLineError(PROGRAM_TERMINATED);
                    break;
                }
                else if(userInput[0] == "--help")
                {
                    var helpController = this.ControllerFactory.GetInformationalController("HelpController");
                    helpController.StateMessage();
                }
                else if (userInput[0] == "--create" && this.LoggedIn)
                {
                    if (userInput[1] == "character")
                    {
                        var characterCreator = this.ControllerFactory.GetController("CreateCharacterController");
                        characterCreator.GuideUser(this.currentUsername);
                    }
                }
                else if (userInput[0] == "--list-characters" && this.LoggedIn)
                {
                    var listController = this.ControllerFactory.GetListCharactersController();
                    listController.ListCharacters(this.CurrentUsername);
                }
                else if (userInput[0] == "--register" && !this.LoggedIn)
                {
                    var registrationController = this.ControllerFactory.GetRegistrationController();
                    string username = registrationController.RegisterUser();

                    if (!string.IsNullOrEmpty(username))
                    {
                        this.LoggedIn = true;
                        this.CurrentUsername = username;
                        this.Writer.WriteLine(SUCCESSEFUL_LOGIN);
                    }
                }
                else if (userInput[0] == "--register" && this.LoggedIn)
                {
                    this.Writer.WriteLineError(LOGOUT_TO_REGISTER);
                }
                else if (userInput[0] == "--login" && !this.LoggedIn)
                {
                    var loginController = this.ControllerFactory.GetLoginController();
                    var username = loginController.Login();

                    if(!string.IsNullOrEmpty(username))
                    {
                        this.LoggedIn = true;
                        this.CurrentUsername = username;
                    }

                }
                else if (userInput[0] == "--logout" && this.LoggedIn)
                {
                    this.LoggedIn = false;
                    this.CurrentUsername = "";
                    this.Writer.WriteLineError(LOGOUT_MESSAGE);
                }
                else if (userInput[0] == "--status" && this.LoggedIn)
                {
                    this.Writer.WriteLineSuccess(string.Format(LOGEDIN_STATUS, this.CurrentUsername));
                }
                else if (userInput[0] == "--status" && !this.LoggedIn)
                {
                    this.Writer.WriteLineError(LOGEDOUT_STATUS);
                }
                else
                {
                    this.Writer.WriteLineError(WRONG_COMMAND);
                }
            }

            var exportFiles = this.ControllerFactory.ExportFiles();
            exportFiles.CreatePDFReport(EXPORT_PATH);
        }
    }
}
