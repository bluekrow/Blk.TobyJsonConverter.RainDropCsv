using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv;

public class TobyCard
{
    public string Title;
    public string Url;
    public string CustomTitle;
    public string CustomDescription;
    private readonly NoteService noteService = new();
    public string Note => noteService
        .GetNote(
            new KeyValuePair<string, string>(nameof(CustomTitle),CustomTitle),
            new KeyValuePair<string, string>(nameof(CustomDescription),CustomDescription) );
}