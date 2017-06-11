using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WoW_Postgre.Models
{
    public class Countries
    {
        private ICollection<Cities> cities;

        public Countries()
        {
            this.Cities = new HashSet<Cities>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

    }
}
