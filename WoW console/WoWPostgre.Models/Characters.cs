using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoW_Postgre.Models
{
    public class Characters
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        [Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
