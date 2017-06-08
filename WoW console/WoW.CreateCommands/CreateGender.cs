using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateGender
    {
        private readonly IWoWDbContext dbContext;

        public CreateGender(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetGender(string name)
        {
            var gender = new Genders()
            {
                Name = name
            };

            this.dbContext.Genders.Add(gender);
        }
    }
}
