using System.Globalization;

namespace TobyJsonToCsv;

public class DateFormatter(string timeText)
{
    public DateTime? DateFromTitle()
    {
        //"May 21 at 14:09"
        return DateTime.TryParseExact(timeText, "MMM dd \"at\" HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateFromTitle)
            ? dateFromTitle
            : null;
    }
    
    public string DateFromTitleAsString()
    {
        return DateFromTitle().HasValue ? DateFromTitle().Value.ToString("s") : string.Empty;
    }

    public string GetDateTag()
    {
        return DateFromTitle().HasValue ? DateFromTitle().Value.ToString("yyyy-MM-dd") : string.Empty;
    }
}