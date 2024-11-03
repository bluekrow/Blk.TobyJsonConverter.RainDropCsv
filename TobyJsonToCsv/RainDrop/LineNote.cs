namespace TobyJsonToCsv.RainDrop;

public class LineNote
{
    private readonly List<KeyValuePair<string,string>> noteParts = [];

    public void AddNotePart(string name, string content)
    {
        noteParts.Add(new KeyValuePair<string, string>(name, content));
    }

    public string GetNoteText()
    {
        var cleanedNoteParts = noteParts
            .Where(notePart => !string.IsNullOrWhiteSpace(notePart.Value))
            .ToList()
            .ConvertAll<string>(notePart => $"{notePart.Key}: {notePart.Value}");

        return string.Join("|",cleanedNoteParts);
    }
}