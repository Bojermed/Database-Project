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
        public int ID { get; set; }

        [StringLength(30)]
        public string userName { get; set; }

        [StringLength(30)]
        public string PasswordHash { get; set; }

        public virtual  Server Servers { get; set; }

        public virtual ICollection<Characters> Character
        {
            get { return this.character; }
            set { this.character = value; }
        }
    }
}
