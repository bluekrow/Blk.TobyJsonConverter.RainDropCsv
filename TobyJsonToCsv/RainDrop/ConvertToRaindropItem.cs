namespace TobyJsonToCsv.RainDrop;

public static class ConvertToRaindropItem
{
    public static RainDropCsvLine ToRainDropItem(this TobyCard tobyCard, TobyCollection tobyCollection)
    {
        var noteSource = new KeyValuePair<string, string>(nameof(tobyCard.CustomTitle), tobyCard.CustomTitle);
        var anotherNoteSource =
            new KeyValuePair<string, string>(nameof(tobyCard.CustomDescription), tobyCard.CustomDescription);

        var dateFormatter = new DateFormatter(tobyCollection.Title);
        var tagCollection = new TagCollection();
        tagCollection.AddTags(tobyCollection.Labels);
        tagCollection.AddTag(dateFormatter.GetDateTag());

        var lineNote = new LineNote();
        
        var rainDropCsvLine = new RainDropCsvLine(tobyCard.Url,
            $"tobyImported/{tobyCollection.Title}",
            tobyCard.Title,
            lineNote.GetNote(noteSource, anotherNoteSource),
            tagCollection.GetTags(),
            dateFormatter.DateFromTitleAsString());
        
        return rainDropCsvLine;
    }
}