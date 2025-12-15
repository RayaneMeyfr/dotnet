using ListeContact.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeContact.data
{
    internal class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {
        }

        public DbSet<Contact> Conctacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=demoefcore;User ID=root;Password=Root;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

    }
}
