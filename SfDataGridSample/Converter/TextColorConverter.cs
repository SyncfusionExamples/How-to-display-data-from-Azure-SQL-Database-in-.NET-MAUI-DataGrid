using System.Globalization;

namespace SfDataGridSample.Converter
{
    public class TextColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if ((decimal)value! < 0)
                return Colors.Red;
            else
                return Colors.Green;


        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
