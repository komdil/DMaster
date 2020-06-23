using Caliburn.Micro;
using DMaster.Model;
using DMaster.Model.Helpers;
using DMaster.ViewModels;
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
            if (IsAuthorized())
            {
                DisplayRootViewFor<MainViewModel>();
            }
            else
            {
                DisplayRootViewFor<AuthViewModel>();
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
