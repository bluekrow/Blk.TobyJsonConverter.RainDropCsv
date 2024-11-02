using System.Globalization;

namespace TobyJsonToCsv;

public class TobyCollection
{
    public string Title;
    public TobyCard[] Cards;
    public string[] Labels;

    public string Tags => GetTags();

    private string GetTags()
    {
        List<string> tags = new List<string>();
        tags.AddRange(Labels.ToList());
        var dateTagFromTitle = DateFromTitle().HasValue ? DateFromTitle().Value.ToString("yyyy-MM-dd"): string.Empty;
        tags.Add(dateTagFromTitle);
        var cleanedTags = tags
            .Where(x => !string.IsNullOrWhiteSpace(x)).ToList()
            .ConvertAll(tag => $"#{tag}");
        
        if (cleanedTags.Count == 0)
            return string.Empty;
        
        if (cleanedTags.Count == 1)
            return cleanedTags[0];
        
        return string.Join("", cleanedTags);
    }

    private DateTime? DateFromTitle()
    {
        //"May 21 at 14:09"
        return DateTime.TryParseExact(Title, "MMM dd \"at\" HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateFromTitle)
            ? dateFromTitle
            : null; 
    }
    
    public string CreationTime => DateFromTitleAsString();

    private string DateFromTitleAsString()
    {
        return DateFromTitle().HasValue ? DateFromTitle().Value.ToString("s") : string.Empty;
    }
}