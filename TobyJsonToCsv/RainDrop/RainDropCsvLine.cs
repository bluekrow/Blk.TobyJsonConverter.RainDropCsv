namespace TobyJsonToCsv.RainDrop;

internal record RainDropCsvLine(
    string Url,
    string Folder,
    string Title,
    string Note,
    string Tags,
    string Created)
{
    public string GetCsvLine()
    {
        return $"{Url}, {Folder}, {Title}, {Note}, {Tags}, {Created}";
    } 
}