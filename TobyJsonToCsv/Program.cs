using System.Runtime.CompilerServices;
using System.Text.Json;
using TobyJsonToCsv.RainDrop;

[assembly: InternalsVisibleTo("TobyJsonToCsv.Tests")]
namespace TobyJsonToCsv
{
    // ReSharper disable once ClassNeverInstantiated.Global
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
            var rainDropCsv = tobyObject!.ToRainDropCsv();

            File.WriteAllLines("/home/raven/Downloads/toby-export-sample.csv", rainDropCsv.GetCsvLines());
        }
    }
}