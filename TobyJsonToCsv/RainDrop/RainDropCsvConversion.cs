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
                rainDropCsv.Lines.Add(tobyCard.ToRainDropItem(tobyCollection));
            }
        }

        return rainDropCsv;
    }
}