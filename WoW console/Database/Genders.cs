using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Genders
    {
        private ICollection<Npcs> npcs;

        public Genders()
        {
            this.npcs = new HashSet<Npcs>();
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
    }
}
