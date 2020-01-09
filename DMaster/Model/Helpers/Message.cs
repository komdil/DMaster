using DMaster.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.Model.Helpers
{
    public class Message
    {
        public static void ShowErrorMsg(string text,bool close=false)
        {
            ErrorMessage errorMessage = new ErrorMessage(close);
            errorMessage.Message.Text = text;
            errorMessage.ShowDialog();
        }
        public static void ShowComMsg(string text)
        {
            ComplatedMessage errorMessage = new ComplatedMessage();
            errorMessage.Message.Text = text;
            errorMessage.ShowDialog();
        }
        public static bool ShowYesNoMsg(string text)
        {
            bool Yes = false;
            YesNoMessage yesno = new YesNoMessage();
            yesno.Closing += Yesno_Closing;  
            yesno.Message.Text = text;
            yesno.ShowDialog();
            void Yesno_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                Yes = yesno.Yes;
            }
            return Yes;
        }

        public static void ShowErrorMsg(string msg, MainContext mainContext)
        {
            ErrorMessage errorMessage = new ErrorMessage();
            errorMessage.Message.Text = msg;
            errorMessage.ShowDialog();
            errorMessage.Closed += ErrorMessage_Closed;
            void ErrorMessage_Closed(object sender, EventArgs e)
            {
                mainContext.Dispose();
            }
        }

       
    }
}
