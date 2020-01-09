using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.Model.Helpers
{
    public static class Helper
    {
        public static void OpenWindow<T>() where T:Conductor<object>
        {
            WindowManager win = new WindowManager();
            win.ShowWindow(Activator.CreateInstance<T>());
        }
        public static T GetWindow<T>(object cocscruct_param) where T : Conductor<object>
        {
            WindowManager win = new WindowManager();
            var res= (T)Activator.CreateInstance(typeof(T), cocscruct_param);
            win.ShowWindow(res);
            return res;
        }
        public static void OpenWindow<T>(object cocscruct_param) where T : Conductor<object>
        {
            WindowManager win = new WindowManager();
            var res = (T)Activator.CreateInstance(typeof(T), cocscruct_param);
            win.ShowWindow(res);
        }
        public static string GetMessage(Exception exception)
        {
            string msgs = "";
            if (exception == null) return string.Empty;
            if (msgs == "") msgs = exception.Message;
            if (exception.InnerException != null)
                msgs += "\r\nInnerException: " + GetMessage(exception.InnerException);
            return msgs;
        }
        public static void ShowDialog<T>(object cocscruct_param) where T : Conductor<object>
        {
            WindowManager win = new WindowManager();
            var res = (T)Activator.CreateInstance(typeof(T), cocscruct_param);
            win.ShowDialog(res);
        }
    }
   
}
