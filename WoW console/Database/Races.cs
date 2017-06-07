using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Races
    {
        private ICollection<Zones> zones;
        private ICollection<Classes> classes;

        public Races()
        {
            this.zones = new HashSet<Zones>();
            this.classes = new HashSet<Classes>();
        }
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Language { get; set; }

        public int ZoneId { get; set; }

        [MaxLength(20)]
        public string Capital { get; set; }

        [MaxLength(20)]
        public string Mount { get; set; }

        public virtual ICollection<Zones> Zones
        {
            get { return this.zones; }
            set { this.zones = value; }
        }

        public ICollection<Classes> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }
    }
}
