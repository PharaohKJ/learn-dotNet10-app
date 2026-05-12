namespace MyServerJob.App;

public static class DateTimeHelper
{
    public static DateTime GetCurrentDateTime()
    {
        return DateTime.Now;
    }

    public static DateTime GetCurrentJstDateTime()
    {
        var jstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo");
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, jstTimeZone);
    }
}
