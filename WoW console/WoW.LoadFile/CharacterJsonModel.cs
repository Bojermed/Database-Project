using Database;
using System;
using System.Linq;
using WoW_console;

namespace WoW.FileLoader
{
    class CharacterJsonModel
    {
        public CharacterJsonModel() { }

        public string Name { get; set; }

        public Players Player { get; set; }

        public Races Race { get; set; }

        public Classes Class { get; set; }

        public Factions Faction { get; set; }

        public Professions Proffesion { get; set; }

        public Func<CharacterJsonModel, IWoWDbContext, Characters> FromJsonModel
        {
            get
            {
                return (jsonModel, db) => 
                {
                    if (!CheckIfPlayerExists(db, jsonModel))
                    {
                        var newCharacter = new Characters
                        {
                            Name = jsonModel.Name,
                            Player = new Players
                            {
                                Username = jsonModel.Player.Username,
                                PasswordHash = jsonModel.Player.PasswordHash,
                                Servers = jsonModel.Player.Servers
                            },
                            Race=jsonModel.Race,
                            Class=jsonModel.Class,
                            Faction=jsonModel.Faction,
                            Profession=jsonModel.Proffesion
                        };

                        return newCharacter;
                    }
                     else
                    {
                        var newCharacter = new Characters
                        {
                            Name = jsonModel.Name,
                            Player = jsonModel.Player,
                            Race = jsonModel.Race,
                            Class = jsonModel.Class,
                            Faction = jsonModel.Faction,
                            Profession = jsonModel.Proffesion
                        };

                        return newCharacter;
                    }
                };
            }
        }

        private bool CheckIfPlayerExists(IWoWDbContext dbContext, CharacterJsonModel jsonModel)
        {
            var foundPlayer = dbContext.Players
                .FirstOrDefault(p => p.Username == jsonModel.Player.Username);

            if (foundPlayer != null)
            {
                return true;
            }

            return false;
        }
    }
}

