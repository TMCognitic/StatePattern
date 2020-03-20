using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace StatePattern.Converters
{
    public class LightColorsToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = value.ToString();
            string colorParameter = (string)parameter;

            if (value.ToString() == (string)parameter)
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString((color == "Green" ? "Light" : "") + color));
            }
            else
            {
                switch(colorParameter)
                {
                    
                    case "Green":
                        return new SolidColorBrush(Color.FromArgb(0x88, 0x00, 0x64, 0x00));
                    case "Orange":
                        return new SolidColorBrush(Color.FromArgb(0x88, 0xFF, 0x8C, 0x00));
                    default:
                        return new SolidColorBrush(Color.FromArgb(0x88, 0x8B, 0x00, 0x00));

                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }        
    }
}
