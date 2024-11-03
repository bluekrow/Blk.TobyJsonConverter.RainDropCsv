using System.Globalization;

namespace TobyJsonToCsv;

public class TobyCollection(string title, TobyCard[] cards, string[] labels)
{
    public readonly string Title = title;
    public readonly TobyCard[] Cards = cards;
    public readonly string[] Labels = labels;
}