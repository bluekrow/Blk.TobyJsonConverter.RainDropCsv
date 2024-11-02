namespace TobyJsonToCsv.RainDrop;

internal class RainDropCsv
{
    public List<RainDropCsvLine> Lines { get; } = [];

    public RainDropCsv()
    {
        var rainDropCsvHeader = new RainDropCsvLine("url", "folder", "title", "note", "tags", "created");
        Lines.Add(rainDropCsvHeader);
    }

    internal List<string> GetCsvLines()
    {
        return Lines.Select(csvLine => csvLine.GetCsvLine()).ToList();
    }
}