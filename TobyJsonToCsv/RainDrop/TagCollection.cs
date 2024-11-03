namespace TobyJsonToCsv.RainDrop;

public class TagCollection
{
    private readonly List<string> tagCollection = [];

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

    public void AddTag(string tag)
    {
        tagCollection.Add(tag);
    }
    public void AddTags(string[] tags)
    {
        tagCollection.AddRange(tags);
    }

    public string GetTags()
    {
        return GetTags(tagCollection.ToArray(),String.Empty);
    }
    
}