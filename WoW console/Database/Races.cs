using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class Races
    {
        private ICollection<Npcs> npcs;
        private ICollection<Classes> classes;

        public Races()
        {
            this.npcs = new HashSet<Npcs>();
            this.classes = new HashSet<Classes>();
        }
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Language { get; set; }

        [Column(TypeName = "ntext")]
        public string Location { get; set; }

        [MaxLength(20)]
        public string Capital { get; set; }

        [MaxLength(20)]
        public string Mount { get; set; }

        public virtual ICollection<Classes> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        public virtual ICollection<Npcs> Npcs
        {
            get { return this.npcs; }
            set { this.npcs = value; }
        }
    }
}
