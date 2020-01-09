using DMaster.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DMaster.Model.Helpers.Comment
{
    public class UserToColorConverter : BaseViewModel,IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value as User).Id==User.Id)
            {
                return "#FF9316";
            }
            else
            {
                return "#3F7AD7";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
