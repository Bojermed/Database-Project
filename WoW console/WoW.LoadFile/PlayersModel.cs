using Database;
using System;
using System.ComponentModel.DataAnnotations;
namespace WoW.LoadFile
{
    [Serializable]
    public class PlayersModel
    {
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string PasswordHash { get; set; }

        public Server Server { get; set; }
    }
}

