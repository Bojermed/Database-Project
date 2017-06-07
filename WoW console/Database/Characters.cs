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
        public int ID { get; set; }

        [StringLength(30)]
        public string name { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }

        public virtual Classes Class { get; set; }

        [ForeignKey("Faction")]
        public int FactionId { get; set; }

        public virtual Factions faction { get; set; }

        [ForeignKey("Race")]
        public int RaceId { get; set; }

        public virtual Races race { get; set; }

        [ForeignKey("Profession")]
        public int ProfessionId { get; set; }

        public virtual Professions mainProfession { get; set; }

        public virtual Professions secondaryProfession { get; set; }
    }
}
