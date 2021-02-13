using Directory.Model.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Model.ORM.Context
{
    public class DirectoryContext : DbContext
    {
        //DB Connection

        public DbSet<Person> People { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
    }
}
