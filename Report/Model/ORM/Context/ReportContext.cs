using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Report.Model.ORM.Entities;


namespace Report.Model.ORM.Context
{
    public class ReportContext :DbContext
    { 
        // DB Connection

        public DbSet<ReportEntity> Reports{ get; set; }

    }
}
