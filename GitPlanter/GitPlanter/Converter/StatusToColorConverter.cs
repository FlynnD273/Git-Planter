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
    internal class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NodeStatus status = (NodeStatus)value;
            Color color = Colors.Black;
            switch (status)
            {
                case NodeStatus.Both:
                    color = Colors.LightGreen;
                    break;
                case NodeStatus.Local:
                    color = Colors.DarkGreen;
                    break;
                case NodeStatus.Remote:
                    color = Colors.SlateGray;
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
