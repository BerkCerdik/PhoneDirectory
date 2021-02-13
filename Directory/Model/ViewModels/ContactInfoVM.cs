using Directory.Model.ORM.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Model.ViewModels
{
    public class ContactInfoVM
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Location { get; set; }      
        [Required]
        public string InformationContent { get; set; }

        [Required]
        public int PersonID { get; set; }

        //[Required]
        //public int PersonID { get; set; }
    }
}
