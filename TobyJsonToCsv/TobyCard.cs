namespace TobyJsonToCsv;

public class TobyCard
{
    public string Title;
    public string Url;
    public string CustomTitle;
    public string CustomDescription;
    public string Note => GetNote();

    private string GetNote()
    {
        var noteLines = new List<KeyValuePair<string,string>>
        {
            new(nameof(CustomTitle), CustomTitle),
            new(nameof(CustomDescription), CustomDescription)
        };

        var cleanedNoteLines = noteLines
            .Where(noteLine => !string.IsNullOrWhiteSpace(noteLine.Value))
            .ToList()
            .ConvertAll<string>(x => $"{x.Key}: {x.Value}");

        //return cleanedNoteLines;
        return string.Join("|",cleanedNoteLines);
    }
}