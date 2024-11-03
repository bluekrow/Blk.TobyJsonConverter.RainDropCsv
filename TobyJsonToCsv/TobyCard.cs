using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv;

public class TobyCard(string title, string url, string customTitle, string customDescription)
{
    public readonly string Title = title;
    public readonly string Url = url;
    public readonly string CustomTitle = customTitle;
    public readonly string CustomDescription = customDescription;
}