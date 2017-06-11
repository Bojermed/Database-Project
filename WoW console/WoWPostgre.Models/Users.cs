using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public virtual ICollection<Characters> Character
        {
            get { return this.character; }
            set { this.character = value; }
        }
    }
}
