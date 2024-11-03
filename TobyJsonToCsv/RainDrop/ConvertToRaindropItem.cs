namespace TobyJsonToCsv.RainDrop;

public static class ConvertToRaindropItem
{
    public static RainDropCsvLine ToRainDropItem(this TobyCard tobyCard, TobyCollection tobyCollection)
    {
        var dateFormatter = new DateFormatter(tobyCollection.Title);

        var tagCollection = new TagCollection();
        tagCollection.AddTags(tobyCollection.Labels);
        tagCollection.AddTag(dateFormatter.GetDateTag());

        var lineNote = new LineNote();
        lineNote.AddNotePart(nameof(tobyCard.CustomTitle),tobyCard.CustomTitle);
        lineNote.AddNotePart(nameof(tobyCard.CustomDescription),tobyCard.CustomDescription);
        
        var rainDropCsvLine = new RainDropCsvLine(tobyCard.Url,
            $"tobyImported/{tobyCollection.Title}",
            tobyCard.Title,
            lineNote.GetNoteText(),
            tagCollection.GetTags(),
            dateFormatter.DateFromTitleAsString());
        
        return rainDropCsvLine;
    }
}