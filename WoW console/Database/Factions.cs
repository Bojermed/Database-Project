using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Database
{
    public class Factions
    {
        private ICollection<Npcs> npcs;

        private ICollection<Characters> characters;

        private ICollection<Races> races;

        public Factions()
        {
            this.npcs = new HashSet<Npcs>();
            this.characters = new HashSet<Characters>();
            this.races = new HashSet<Races>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Npcs> Npcs
        {
            get { return this.npcs; }
            set { this.npcs = value; }
        }

        public virtual ICollection<Characters> Characters
        {
            get { return this.characters; }
            set { this.characters = value; }
        }

        public virtual ICollection<Races> Races
        {
            get { return this.races; }
            set { this.races = value; }
        }

    }
}
