namespace TobyJsonToCsv.RainDrop;

public class NoteService
{
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
}