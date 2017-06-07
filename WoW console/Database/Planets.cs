using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Planets
    {
        private ICollection<Continents> continents;

        public Planets()
        {
              this.continents = new HashSet<Continents>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Continents> Continents 
        {
            get { return this.continents; }
            set { this.continents = value; }
        }
    }
}
