using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Continents
    {
        private ICollection<Zones> zones;

        public Continents()
        {
            this.zones = new HashSet<Zones>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public int PlanetId { get; set; }

        [Required]
        public virtual Planets Planet { get; set; }

        public virtual ICollection<Zones> Zones
        {
            get { return this.zones; }
            set { this.zones = value; }
        }
    }
}
