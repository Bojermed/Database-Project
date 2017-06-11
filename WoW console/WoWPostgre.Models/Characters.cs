using System.ComponentModel.DataAnnotations;

namespace WoW_Postgre.Models
{
    public class Characters
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
