using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class Classes
    {
        private ICollection<Races> races;

        public Classes()
        {
            this.races = new HashSet<Races>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public int ResourceId { get; set; }

        [Column(TypeName = "ntext")]
        public string Lore { get; set; }

        public virtual Resources Resource { get; set; }

        public virtual ICollection<Races> Races
        {
            get { return this.races; }
            set { this.races = value; }
        }
    }
}
