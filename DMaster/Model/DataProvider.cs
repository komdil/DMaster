using DMaster.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DMaster.Model
{
    public class DataProvider
    {

        public Dictionary<string, ObservableCollection<EntityBase>> BaseEntities { get; set; }
        public DataProvider()
        {
            Context = new MainContext();
            if (Context.IsConnectionLost)
            {
                string msg = $"Can not connect to Server!!! \n {Context.ErrorMessage}";
                Message.ShowErrorMsg(msg, true);
            }
            else
            {
                Load();
            }
        }
        private void Load()
        {
            BaseEntities = new Dictionary<string, ObservableCollection<EntityBase>>();
            BaseEntities.Add(nameof(User), new ObservableCollection<EntityBase>(Context.Set<User>()));
            BaseEntities.Add(nameof(DTask), new ObservableCollection<EntityBase>(Context.Set<DTask>()));
            BaseEntities.Add(nameof(Machine), new ObservableCollection<EntityBase>(Context.Set<Machine>()));
            BaseEntities.Add(nameof(Authorize), new ObservableCollection<EntityBase>(Context.Set<Authorize>()));
            BaseEntities.Add(nameof(Period), new ObservableCollection<EntityBase>(Context.Set<Period>()));
            BaseEntities.Add(nameof(Project), new ObservableCollection<EntityBase>(Context.Set<Project>()));
            BaseEntities.Add(nameof(Comment), new ObservableCollection<EntityBase>(Context.Set<Comment>()));
        }
        public MainContext Context { get; set; }
        public void AddEntity<T>(T entity) where T : EntityBase
        {
            Context.Set<T>().Add(entity);
            BaseEntities[Activator.CreateInstance<T>().GetType().Name].Add(entity);
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        public ObservableCollection<T> GetEntity<T>() where T : EntityBase
        {
            return new ObservableCollection<T>(BaseEntities[Activator.CreateInstance<T>().GetType().Name].Cast<T>());
        }
        public bool ExistsProperty<T>(T entity, string Property) where T : EntityBase
        {
            var property = entity.GetType().GetProperty(Property);
            var result = property.GetValue(entity);
            var exists = BaseEntities[Activator.CreateInstance<T>().GetType().Name].Any(a => a.GetType().GetProperty(Property).GetValue(a).Equals(result));
            return exists;
        }
        public void Remove<T>(T entity) where T : EntityBase
        {
            Context.Set<T>().Remove(entity);
            BaseEntities[Activator.CreateInstance<T>().GetType().Name].Remove(entity);
        }


    }
}
