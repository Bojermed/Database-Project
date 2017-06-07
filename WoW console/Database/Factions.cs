using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Database
{
    public class Factions
    {
        private ICollection<Npcs> npcs;

        private ICollection<Characters> characters;

        public Factions()
        {
            this.npcs = new HashSet<Npcs>();
            this.characters = new HashSet<Characters>();
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
    }
}
