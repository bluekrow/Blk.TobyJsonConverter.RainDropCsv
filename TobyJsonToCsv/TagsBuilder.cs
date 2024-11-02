using System.Globalization;

namespace TobyJsonToCsv;

public class TagsBuilder
{
    public string GetTags(string[] tagSources, string additionalTagSource)
    {
        var tags = new List<string>();
        tags.AddRange(tagSources.ToList());
        tags.Add(additionalTagSource);
        var cleanedTags = tags
            .Where(x => !string.IsNullOrWhiteSpace(x)).ToList()
            .ConvertAll(tag => $"#{tag}");
        
        return string.Join("", cleanedTags);
    }
}