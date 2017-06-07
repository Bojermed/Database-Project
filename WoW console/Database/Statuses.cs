using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Database
{
    public class Statuses
    {
        private ICollection<Npcs> npcs;

        public Statuses()
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
