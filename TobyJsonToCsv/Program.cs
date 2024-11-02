using System.Runtime.CompilerServices;
using System.Text.Json;

[assembly: InternalsVisibleTo("TobyJsonToCsv.Tests")]
namespace TobyJsonToCsv
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tobyJsonContent = File.ReadAllText("/home/raven/Downloads/toby-export-sample.json");
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNameCaseInsensitive = true
            };
            var tobyObject = JsonSerializer.Deserialize<TobyObject>(tobyJsonContent, jsonSerializerOptions);
            var rainDropFileLines = new List<string>();
            rainDropFileLines.Add("url, folder, title, note, tags, created");

            foreach (var tobyCollection in tobyObject.Lists)
            {
                foreach (var tobyCard in tobyCollection.Cards)
                {
                    var rainDropItem = new RainDropItem(tobyCard.Url, $"tobyImported/{tobyCollection.Title}",
                        tobyCard.Title, tobyCard.Note,
                        tobyCollection.Tags, tobyCollection.CreationTime);
                    var rainDropLine = rainDropItem.GetCsvLine();
                    rainDropFileLines.Add(rainDropLine);
                }
            }

            File.WriteAllLines("/home/raven/Downloads/toby-export-sample.csv", rainDropFileLines);
        }
    }
}