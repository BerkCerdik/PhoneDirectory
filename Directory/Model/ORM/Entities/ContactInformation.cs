using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Model.ORM.Entities
{
    public class ContactInformation : BaseEntity
    {
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Location { get; set; }
        public int PersonID { get; set; }
        public string InformationContent{ get; set; }

        [ForeignKey("PersonID")]
        public Person Person { get; set; }
    }
}
