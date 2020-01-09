using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DMaster.Views
{
    /// <summary>
    /// Interaction logic for YesNoMessage.xaml
    /// </summary>
    public partial class YesNoMessage : Window
    {
        public YesNoMessage()
        {
            InitializeComponent();
        }
        public bool Yes { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
