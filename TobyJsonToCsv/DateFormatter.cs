using System.Globalization;

namespace TobyJsonToCsv;

public class DateFormatter
{
    public DateTime? DateFromTitle(string dateTimeText)
    {
        //"May 21 at 14:09"
        return DateTime.TryParseExact(dateTimeText, "MMM dd \"at\" HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateFromTitle)
            ? dateFromTitle
            : null; 
    }

    public string DateFromTitleAsString(string dateTimeText)
    {
        return DateFromTitle(dateTimeText).HasValue ? DateFromTitle(dateTimeText).Value.ToString("s") : string.Empty;
    }
}