using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Zones
    {
        private ICollection<Npcs> npcs;

        public Zones()
        {
            this.npcs = new HashSet<Npcs>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public int ContinentId { get; set; }

        [Required]
        public virtual Continents Continent { get; set; }

        public virtual ICollection<Npcs> Npcs 
        {
            get { return this.npcs; }
            set { this.npcs = value; }
        }
    }
}
