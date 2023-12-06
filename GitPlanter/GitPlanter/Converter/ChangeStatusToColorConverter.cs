using GitPlanter.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GitPlanter.Converter
{
    internal class ChangeStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ChangeStatus status = (ChangeStatus)value;
            Color color = Colors.Black;
            switch (status)
            {
                case ChangeStatus.Added:
                    color = Colors.LightGreen;
                    break;
                case ChangeStatus.Modified:
                    color = Colors.LightBlue;
                    break;
                case ChangeStatus.Renamed:
                    color = Colors.LightCoral;
                    break;
                case ChangeStatus.Removed:
                    color = Colors.LightPink;
                    break;
            }
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
