using System.Windows;

namespace DMaster.Views
{
    /// <summary>
    /// Interaction logic for ComplatedMessage.xaml
    /// </summary>
    public partial class ComplatedMessage : Window
    {
        public ComplatedMessage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
