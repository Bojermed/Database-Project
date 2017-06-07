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
        public int ID { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        public string PasswordHash { get; set; }

        public virtual  Server Servers { get; set; }
    }
}
