namespace quickOS.Core.Utils;

public static class DateTimeUtils
{
    public static DateTime GetBrasiliaTime()
    {
        var zoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zoneInfo);
    }

    public static DateTime ConvertToBrasiliaTime(DateTime date)
    {
        var zoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(date, zoneInfo);
    }
}
