﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Model.ORM.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
