using Database;

namespace WoW_console
{
    class Program
    {
        static void Main()
        {
            var dbContext = new WoWDbContext();

            var azeroth = new Planets() 
            {
                Name = "Azeroth"
            };

            dbContext.Planets.Add(azeroth);
        }
    }
}
