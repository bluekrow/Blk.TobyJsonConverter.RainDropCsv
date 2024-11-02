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
        var rainDropCsvLine = new RainDropCsvLine(tobyCard.Url, 
            $"tobyImported/{tobyCollection.Title}", 
            tobyCard.Title, 
            tobyCard.Note,
            tobyCollection.Tags,
            tobyCollection.CreationTime);
        return rainDropCsvLine;
    }
}