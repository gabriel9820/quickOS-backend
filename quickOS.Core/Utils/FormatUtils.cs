using System.Globalization;

namespace quickOS.Core.Utils;

public static class FormatUtils
{
    public static string FormatDouble(double value, int decimalPlaces)
    {
        var cultureInfo = new CultureInfo("pt-BR");
        var format = "N" + decimalPlaces;

        return value.ToString(format, cultureInfo);
    }

    public static string FormatDecimal(decimal value, int decimalPlaces)
    {
        var cultureInfo = new CultureInfo("pt-BR");
        var format = "N" + decimalPlaces;

        return value.ToString(format, cultureInfo);
    }
}
