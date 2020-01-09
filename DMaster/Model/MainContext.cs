using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using System.Collections.Specialized;
using System.Configuration;
using DMaster.Model.Helpers;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace DMaster.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public string Host => Database.Connection.DataSource;
        public bool IsConnectionLost { get; set; }
        public string ErrorMessage { get; set; } = "";
        public bool IsConnectionSuccess()
        {
            try
            {
                Ping myPing = new Ping();
                String host = Database.Connection.DataSource;
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    Database.Connection.Open();
                    Database.Connection.Close();
                }
                else
                {
                    ErrorMessage = $"Ping to addess {host} is not success";
                    IsConnectionLost = true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                IsConnectionLost = true;
                ErrorMessage = Helper.GetMessage(ex);
                return false;
            }
            return true;
        }

        public MainContext() : base(GetConnectionString("DSprint"))
        {
            if (IsConnectionSuccess())
            {
                if (!Database.Exists())
                {
                    Database.Create();
                    BlankData();
                }
                Configuration.LazyLoadingEnabled = true;
                Configuration.ProxyCreationEnabled = true;
            }
        }
        private void BlankData()
        {
            Users.Add(new User { Id = "Any", Possession = UserPossession.Junior, Password = "Any" });
            Users.Add(new User { Id = "Super", Possession = UserPossession.Super, Password = "Super" });
            SaveChanges();
        }

        #region Mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            UserMapping(modelBuilder);
            DTaskMapping(modelBuilder);
            AuthMapping(modelBuilder);
            MachineMapping(modelBuilder);
            PeriodMapping(modelBuilder);
            ProjectMapping(modelBuilder);
            CommentMapping(modelBuilder);
        }

        private void CommentMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Comment>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Comment>().HasRequired(a => a.User).WithMany(m => m.Comments).HasForeignKey(k => k.UserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Comment>().HasRequired(a => a.Task).WithMany(m => m.Comments).HasForeignKey(k => k.TaskId).WillCascadeOnDelete(true);
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
            modelBuilder.Entity<DTask>().HasRequired(a => a.Validator).WithMany(m => m.ValidateTasks).HasForeignKey(k => k.ValidatorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<DTask>().HasRequired(a => a.CreatedBy).WithMany(m => m.CreatedTasks).HasForeignKey(k => k.CreatedById).WillCascadeOnDelete(false);
            modelBuilder.Entity<DTask>().HasRequired(a => a.Period).WithMany(m => m.Tasks).HasForeignKey(k => k.PeriodId).WillCascadeOnDelete(true);
        }
        void MachineMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>().ToTable("Machine");
            modelBuilder.Entity<Machine>().HasKey(s => new { s.Id });
        }
        void AuthMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authorize>().ToTable("Authorize");
            modelBuilder.Entity<Authorize>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Authorize>().HasRequired(a => a.Machine).WithMany(a => a.Authorizes).HasForeignKey(a => a.MachineId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Authorize>().HasRequired(a => a.User).WithMany(a => a.Authorizes).HasForeignKey(a => a.UserId).WillCascadeOnDelete(false);
        }
        void PeriodMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>().ToTable("Period");
            modelBuilder.Entity<Period>().HasKey(s => new { s.Id });
            modelBuilder.Entity<Period>().HasRequired(a => a.Project).WithMany(a => a.Periods).HasForeignKey(a => a.ProjectId).WillCascadeOnDelete(true);
        }
        void ProjectMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Project>().HasKey(s => new { s.Id });
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

        #endregion

    }
    public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext dbContext)
        {
            base.Seed(dbContext);
        }
    }
}
