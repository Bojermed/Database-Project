using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Resources
    {
        private ICollection<Classes> classes;

        public Resources()
        {
            this.classes = new HashSet<Classes>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Classes> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }
    }
}
