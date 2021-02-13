using Directory.Model.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Model.ViewModels
{
    public class DirectoryListVM
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string Company { get; set; }
        public List<ContactInformation> ContactInfoList { get; set; }

    }
}
