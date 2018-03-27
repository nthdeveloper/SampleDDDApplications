using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.Entities;

namespace PersonApp.Persistence.EntityFramework
{
    partial class PersonDbContext : DbContext
    {
        public DbSet<PersonEntity> Persons { get; set; }

        public PersonDbContext():this("name=PersonConnection")
        {

        }

        public PersonDbContext(string connectionString)
            :base(connectionString)
        {
            Database.SetInitializer<PersonDbContext>(null);
        }
    }
}
