using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoW_Postgre.Models
{
    public class Cities
    {
        private ICollection<Users> users;

        public Cities()
        {
            this.Users = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        [Index("CountryIndex", IsUnique = true)]
        public string Name { get; set; }

        public int CountriesId { get; set; }

        public virtual ICollection<Users> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
