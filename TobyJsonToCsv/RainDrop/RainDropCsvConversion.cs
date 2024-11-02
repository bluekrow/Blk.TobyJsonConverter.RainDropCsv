namespace TobyJsonToCsv.RainDrop;

internal static class RainDropCsvConversion
{
    internal static RainDropCsv ToRainDropCsv(this TobyObject tobyObject)
    {
        var rainDropCsv = new RainDropCsv();
        foreach (var tobyCollection in tobyObject.Lists)
        {
            foreach (var tobyCard in tobyCollection.Cards)
            {
                rainDropCsv.Lines.Add(tobyCard.ToRainDropCsvLine(tobyCollection));
            }
        }

        return rainDropCsv;
    }

    private static RainDropCsvLine ToRainDropCsvLine(this TobyCard tobyCard, TobyCollection tobyCollection)
    {
        var noteSource = new KeyValuePair<string, string>(nameof(tobyCard.CustomTitle), tobyCard.CustomTitle);
        var anotherNoteSource =
            new KeyValuePair<string, string>(nameof(tobyCard.CustomDescription), tobyCard.CustomDescription);

        var rainDropCsvLine = new RainDropCsvLine(tobyCard.Url,
            $"tobyImported/{tobyCollection.Title}",
            tobyCard.Title,
            GetNote(noteSource, anotherNoteSource),
            tobyCollection.Tags,
            tobyCollection.CreationTime);
        return rainDropCsvLine;
    }
    
    private static string GetNote(KeyValuePair<string, string> noteSource, KeyValuePair<string, string> anotherNoteSource)
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