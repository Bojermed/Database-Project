using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Index("CityIndex", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

    }
}
