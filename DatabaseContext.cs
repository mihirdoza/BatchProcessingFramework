using BatchProcessingFramework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=MySQLConnection")
        {
            // Get the ObjectContext related to this DbContext
            // var objectContext = (this as IObjectContextAdapter).ObjectContext;
            Database.SetInitializer<DatabaseContext>(null);
            //// Sets the command timeout for all the commands
            //objectContext.CommandTimeout = int.MaxValue;
        }

        public DbSet<AppAp> AppAP { get; set; }
        public DbSet<BatchInstance> BatchInstance { get; set; }
        public DbSet<BatchInstanceDataSet> BatchInstanceDataSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
