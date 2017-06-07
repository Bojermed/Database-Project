using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ClassesName
    {/// <summary>
    /// to delete
    /// </summary>
        private ICollection<Classes> gameClass;
        private ICollection<Resources> resource;

        public ClassesName()
        {
            this.gameClass = new HashSet<Classes>();
        }
        public int ID { get; set; }

        public string name { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }

        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        public virtual ICollection<Classes> GameClass
        {
            get { return this.gameClass; }
            set { this.gameClass = value; }
        }

        public virtual ICollection<Resources> Resource
        {
            get { return this.resource; }
            set { this.resource = value; }
        }
    }
}
