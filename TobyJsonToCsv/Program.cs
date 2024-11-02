using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;

[assembly: InternalsVisibleTo("TobyJsonToCsv.Tests")]
namespace TobyJsonToCsv
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var tobyJsonContent = File.ReadAllText("/home/raven/Downloads/toby-export-sample.json");
            Console.WriteLine(tobyJsonContent.Length); //3754

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNameCaseInsensitive = true
            };
            var tobyObject = JsonSerializer.Deserialize<TobyObject>(tobyJsonContent, jsonSerializerOptions);
            if (tobyObject == null)
            {
                Console.WriteLine("tobyObject is null");
                return;
            }

            Console.WriteLine(tobyObject.Version);
            Console.WriteLine(tobyObject.Lists.Length);
            Console.WriteLine(tobyObject.Lists[0].Title);

            Console.WriteLine("-------------");

            var rainDropFileLines = new List<string>();
            rainDropFileLines.Add("url, folder, title, note, tags, created");
            Console.WriteLine("url, folder, title, note, tags, created");

            foreach (var tobyCollection in tobyObject.Lists)
            {
                foreach (var tobyCard in tobyCollection.Cards)
                {
                    var rainDropItem = new RainDropItem(tobyCard.Url, $"tobyImported/{tobyCollection.Title}",
                        tobyCard.Title, tobyCard.Note,
                        tobyCollection.Tags, tobyCollection.CreationTime);
                    var rainDropLine = rainDropItem.GetCsvLine();
                    Console.WriteLine(rainDropLine);
                    rainDropFileLines.Add(rainDropLine);
                }
            }

            File.WriteAllLines("/home/raven/Downloads/toby-export-sample.csv", rainDropFileLines);
        }
    }
}


public class TobyObject
{
    public int Version;
    public required TobyCollection[] Lists;
}

public class TobyCollection
{
    public string Title;
    public TobyCard[] Cards;
    public string[] Labels;

    public string Tags => GetTags();

    private string GetTags()
    {
        List<string> tags = new List<string>();
        tags.AddRange(Labels.ToList());
        var dateTagFromTitle = DateFromTitle().HasValue ? DateFromTitle().Value.ToString("yyyy-MM-dd"): string.Empty;
        tags.Add(dateTagFromTitle);
        var cleanedTags = tags
            .Where(x => !string.IsNullOrWhiteSpace(x)).ToList()
            .ConvertAll(tag => $"#{tag}");
        
        if (cleanedTags.Count == 0)
            return string.Empty;
        
        if (cleanedTags.Count == 1)
            return cleanedTags[0];
        
        return string.Join("", cleanedTags);
    }

    private DateTime? DateFromTitle()
    {
        //"May 21 at 14:09"
        return DateTime.TryParseExact(Title, "MMM dd \"at\" HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateFromTitle)
            ? dateFromTitle
            : null; 
    }
    
    public string CreationTime => DateFromTitleAsString();

    private string DateFromTitleAsString()
    {
        return DateFromTitle().HasValue ? DateFromTitle().Value.ToString("s") : string.Empty;
    }
}
public class TobyCard
{
    public string Title;
    public string Url;
    public string CustomTitle;
    public string CustomDescription;
    public string Note => GetNote();

    private string GetNote()
    {
        var noteLines = new List<KeyValuePair<string,string>>
        {
            new(nameof(CustomTitle), CustomTitle),
            new(nameof(CustomDescription), CustomDescription)
        };

        var cleanedNoteLines = noteLines
            .Where(noteLine => !string.IsNullOrWhiteSpace(noteLine.Value))
            .ToList()
            .ConvertAll<string>(x => $"{x.Key}: {x.Value}");

        //return cleanedNoteLines;
        return string.Join("|",cleanedNoteLines);
    }
}


public record RainDropItem(
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