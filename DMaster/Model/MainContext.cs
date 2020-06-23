using System.Data.Entity;
using SQLite.CodeFirst;
using System.Linq;
using System;
using System.Collections.Generic;

namespace DMaster.Model
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MainContext() : base("DSprint")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public void BlankData()
        {
            Users.Add(new User { Id = "Any", Possession = UserPossession.Junior, Password = "Any" });
            Users.Add(new User { Id = "Super", Possession = UserPossession.Super, Password = "Super" });
            SaveChanges();
        }

        #region Mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            UserMapping(modelBuilder);
            DTaskMapping(modelBuilder);
            AuthMapping(modelBuilder);
            MachineMapping(modelBuilder);
            PeriodMapping(modelBuilder);
            ProjectMapping(modelBuilder);
            CommentMapping(modelBuilder);


            var initializer = new ContextDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
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

        #endregion


        #region Crud


        public List<T> GetEntities<T>() where T : class
        {
            return Set<T>().ToList();
        }


        public void AddEntity<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        #endregion
    }
    public class ContextDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<MainContext>
    {
        public ContextDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        { }

        protected override void Seed(MainContext context)
        {
            context.BlankData();
        }
    }

    public class CustomHistory : IHistory
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Context { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
