namespace TobyJsonToCsv.RainDrop;

public class LineNote
{
    private readonly List<KeyValuePair<string,string>> noteParts = [];

    public string GetNote(KeyValuePair<string, string> noteSource, KeyValuePair<string, string> anotherNoteSource)
    {
        var noteLines = new List<KeyValuePair<string,string>>
        {
            noteSource,
            anotherNoteSource
        };

        var cleanedNoteLines = noteLines
            .Where(noteLine => !string.IsNullOrWhiteSpace(noteLine.Value))
            .ToList()
            .ConvertAll<string>(x => $"{x.Key}: {x.Value}");

        return string.Join("|",cleanedNoteLines);
    }

    public void AddNotePart(string name, string content)
    {
        noteParts.Add(new KeyValuePair<string, string>(name, content));
    }

    public string GetNote()
    {
        return GetNote(noteParts[0], noteParts[1]);
    }
}