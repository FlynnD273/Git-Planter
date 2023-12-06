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
    internal class StatusToTooltipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NodeStatus status = (NodeStatus)value;
            switch (status)
            {
                case NodeStatus.Both:
                    return "Commit is already pushed to remote";
                case NodeStatus.LocalHead:
                    return "Latest pushed changed";
                case NodeStatus.Local:
                    return "Click to push changes";
                case NodeStatus.Remote:
                    return "Click to pull changes";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
