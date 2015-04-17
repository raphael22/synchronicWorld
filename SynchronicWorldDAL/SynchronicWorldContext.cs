using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldDAL
{
    public class SynchronicWorldContext : DbContext
    {
        public SynchronicWorldContext() : base("SynchronicWorldContext"){
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<SynchronicWorldContext>(new SynchronicWorldInitializer());
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
