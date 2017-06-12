using Database;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WoW.Exports
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

        public static Func<CharacterJsonModel, Characters> FromJsonModel
        {
            get
            {
                return jsonModel => new Characters
                {
                    Name = jsonModel.Name,
                    Player = new Players
                    {
                        Username = jsonModel.Player.Username
                        //Passwordhash = jsonModel.Player.Passwordhash;
                    },
                    Race = new Races
                    {
                        Name = jsonModel.Race.Name,
                        Language = jsonModel.Race.Language,
                        Location = jsonModel.Race.Location,
                        Capital = jsonModel.Race.Capital,
                        Mount = jsonModel.Race.Mount
                    },
                    Class = new Classes
                    { Name = jsonModel.Class.Name
                    },
                    Faction = new Factions
                    {
                        Name = jsonModel.Faction.Name
                    },
                    Profession = new Professions
                    {
                        Name = jsonModel.Proffesion.Name
                    }
                };
            }
        }
    }
}
