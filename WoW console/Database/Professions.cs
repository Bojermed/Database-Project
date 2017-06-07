using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Professions
    {
        private ICollection<ProfessionTypes> profType;
        private ICollection<Characters> character;

        public Professions()
        {
            this.profType = new HashSet<ProfessionTypes>(); //?? enum>??
            this.character= new HashSet<Characters>();
        }

        public int ID { get; set; }

        public string name { get; set; }

        // public ProfessionTypes profType { get; set; }

        [ForeignKey("ProfessionType")]
        public int ProfessionTypeId { get; set; }

        public virtual ICollection<ProfessionTypes> ProfType
        {
            get { return this.profType;}
            set{ this.profType=value; }
        }

        public virtual ICollection<Characters> Character
        {
            get { return this.character; }
            set { this.character = value; }
        }
    }
}
