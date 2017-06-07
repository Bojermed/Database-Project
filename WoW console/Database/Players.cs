using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Players
    {
        private ICollection<Characters> character;

        public Players()
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

        public virtual  Server Servers { get; set; }

        public virtual ICollection<Characters> Character
        {
            get { return this.character; }
            set { this.character = value; }
        }
    }
}
