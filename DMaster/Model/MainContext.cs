using MySql.Data.EntityFramework;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DMaster.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MainContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<DTask> Tasks { get; set; }
        public MainContext() : base("server=db4free.net;database=komdilsprint;username=komdil;password=xavi1066")
        {
            Database.Delete();
            Database.CreateIfNotExists();
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            UserMapping(modelBuilder);
            DTaskMapping(modelBuilder);
        }
        void UserMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(s => new { s.Id });
        }
        void DTaskMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTask>().ToTable("DTask");
            modelBuilder.Entity<DTask>().HasKey(s => new { s.Id });
            modelBuilder.Entity<DTask>().HasRequired(a => a.Assignee).WithMany(m => m.Tasks).HasForeignKey(k => k.AssigneeId);
            modelBuilder.Entity<DTask>().HasRequired(a => a.Validator).WithMany(m => m.ValidateTasks).HasForeignKey(k => k.ValidatorId).WillCascadeOnDelete(false); ;
            modelBuilder.Entity<DTask>().HasRequired(a => a.CreatedBy).WithMany(m => m.CreatedTasks).HasForeignKey(k => k.CreatedById).WillCascadeOnDelete(false); ;

        }
        static string GetConnectionString(string dbName)
        {
            if (ConfigurationManager.ConnectionStrings != null)
            {
                var connString = ConfigurationManager.ConnectionStrings["mysqlCon"].ConnectionString;
                return String.Format(connString, dbName);
            }
            return "";
        }

    }
    public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext dbContext)
        {
            base.Seed(dbContext);
        }
    }
}
