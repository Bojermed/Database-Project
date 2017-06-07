using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Database
{
    public class Npcs
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Titles { get; set; }

        public int? Health { get; set; }

        public int GenderId { get; set; }

        public int RaceId { get; set; }

        public int ClassId { get; set; }

        public int FactionId { get; set; }

        public int StatusId { get; set; }

        public int ZoneId { get; set; }

        [Required]
        public virtual Genders Gender { get; set; }

        [Required]
        public virtual Races Race { get; set; }

        [Required]
        public virtual Classes Class { get; set; }

        [Required]
        public virtual Factions Faction { get; set; }

        [Required]
        public virtual Statuses Status { get; set; }

        [Required]
        public virtual Zones Zone { get; set; }
    }
}
