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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-52-209-134-160.eu-west-1.compute.amazonaws.com;Database=d68fhj4cdnhoh0;UID=ciinwhxmoazmfy;PWD=ba797a428b37492d5666c8e870cd667995b0e200ba29cd4bd85ac98f3bdf75cb;SSL Mode= Require;TrustServerCertificate=True");
        }


        public DbSet<Person> People { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
    }
}
