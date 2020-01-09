using Caliburn.Micro;
using DMaster.Model;
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
            DataProvider DataProvider = new DataProvider();
            var mac = Machine.GetProcessorId();
            return DataProvider.GetEntity<Authorize>().Any(a => a.Machine.ProcessorId == mac);
        }
    }
}
