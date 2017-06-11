using WoW_console.Contracts;

namespace WoW_console
{
    public class Engine : IEngine
    {
        private const string PROMPT_USER = "You can enter a new command:";
        private const string PROGRAM_TERMINATED = "Program has been terminated.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IControllerFactory controllerFactory;

        public Engine(IReader reader, IWriter writer, IControllerFactory controllerFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.controllerFactory = controllerFactory;
        }

        public IReader Reader { get; }

        public IWriter Writer { get; }

        public IControllerFactory ControllerFactory { get; }

        public void Start()
        {
            // add starting screan controller

            while(true)
            {
                this.Writer.WriteLine(PROMPT_USER);
                var userInput = this.reader.ReadLine().ToLower().Split(' ');

                if(userInput[0] == "exit")
                {
                    this.Writer.WriteLine(PROGRAM_TERMINATED);
                    break;
                }
                else if (userInput[1] == "planet")
                {
                    var planetCreator = this.ControllerFactory.GetController("CreatePlanetController");
                    planetCreator.GuideUser();
                }
            }
        }
    }
}
