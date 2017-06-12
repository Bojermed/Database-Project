using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Characters
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        public int PlayerId { get; set; }

        public int RaceId { get; set; }

        public int ClassId { get; set; }
   
        public int FactionId { get; set; }

        public int ProfessionId { get; set; }

        public virtual Players Player { get; set; }

        public virtual Races Race { get; set; }

        public virtual Classes Class { get; set; }

        public virtual Factions Faction { get; set; }

        public virtual Professions Profession { get; set; }
    }
}
