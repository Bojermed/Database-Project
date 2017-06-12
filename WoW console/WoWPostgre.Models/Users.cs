using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoW_Postgre.Models
{
    public class Users
    {

        private ICollection<Characters> character;

        public Users()
        {
            this.character = new HashSet<Characters>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Username { get; set; }

        [StringLength(30)]
        [Required]
        public string PasswordHash { get; set; }

        public int CitiesId { get; set; }

        [StringLength(30)]
        [Required]
        [Index("EmailIndex", IsUnique = true)]
        public string Email { get; set; }

        public virtual ICollection<Characters> Character
        {
            get { return this.character; }
            set { this.character = value; }
        }
    }
}
