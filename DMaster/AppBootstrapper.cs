using Caliburn.Micro;
using DMaster.Model;
using DMaster.Model.Helpers;
using DMaster.ViewModels;
using OceanAirdrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DMaster
{
    public class AppBootstrapper : BootstrapperBase
    {

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            LocalSqllite.CreateNewSQLLiteDatabase();
            //Import();

            if (IsAuthorized())
            {
                DisplayRootViewFor<MainViewModel>();
            }
            else
            {
                DisplayRootViewFor<AuthViewModel>();
            }

        }
        void Import()
        {
            var context = Global.MainContext;
            var allTasks = context.GetEntities<DTask>().ToList();
            foreach (var item in allTasks)
            {
                string sql = string.Format("INSERT INTO [timer_types] (pmo_number, description) VALUES ('{0}', '{1}')", item.Id.ToString(), item.Title);
                var res = LocalSqllite.ExecSQLCommand(sql);
                if (!res)
                {

                }
            }
        }

        public bool IsAuthorized()
        {
            var context = Global.MainContext;
            var mac = Machine.GetProcessorId();
            return context.GetEntities<Authorize>().Any(a => a.Machine.ProcessorId == mac);
        }
    }
}
