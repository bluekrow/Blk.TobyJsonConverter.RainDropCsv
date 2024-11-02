using System.Globalization;

namespace TobyJsonToCsv;

public class TobyCollection
{
    public string Title;
    public TobyCard[] Cards;
    public string[] Labels;

    public string Tags => GetTags(Labels, DateFromTitle(Title).HasValue ? DateFromTitle(Title).Value.ToString("yyyy-MM-dd"): string.Empty);

    private string GetTags(string[] tagSources, string additionalTagSource)
    {
        var tags = new List<string>();
        tags.AddRange(tagSources.ToList());
        tags.Add(additionalTagSource);
        var cleanedTags = tags
            .Where(x => !string.IsNullOrWhiteSpace(x)).ToList()
            .ConvertAll(tag => $"#{tag}");
        
        return string.Join("", cleanedTags);
    }

    private DateTime? DateFromTitle(string dateTimeText)
    {
        //"May 21 at 14:09"
        return DateTime.TryParseExact(dateTimeText, "MMM dd \"at\" HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateFromTitle)
            ? dateFromTitle
            : null; 
    }
    
    public string CreationTime => DateFromTitleAsString();

    private string DateFromTitleAsString()
    {
        return DateFromTitle(Title).HasValue ? DateFromTitle(Title).Value.ToString("s") : string.Empty;
    }
}