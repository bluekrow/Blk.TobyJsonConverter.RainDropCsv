namespace TobyJsonToCsv.RainDrop;

public class TagCollection
{
    private readonly List<string> tagCollection = [];

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
        var cleanedTags = tagCollection
            .Where(x => !string.IsNullOrWhiteSpace(x)).ToList()
            .ConvertAll(tag => $"#{tag}");
        return string.Join("", cleanedTags);
    }
}