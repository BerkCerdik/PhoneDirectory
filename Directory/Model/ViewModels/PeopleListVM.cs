﻿using Directory.Model.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Model.ViewModels
{
    public class PeopleListVM
    {
        public int PeopleID { get; set; }
        public string PeopleName { get; set; }
        public string PeopleSurname { get; set; }
        public string PeopleCompany { get; set; }
        public bool IsDeleted { get; set; }
        public List<ContactInformation> ContactInfoList { get; set; }

    }
}
