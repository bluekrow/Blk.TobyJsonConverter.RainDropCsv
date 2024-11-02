using System.Runtime.CompilerServices;
using System.Text.Json;
using TobyJsonToCsv.RainDrop;

[assembly: InternalsVisibleTo("TobyJsonToCsv.Tests")]
namespace TobyJsonToCsv
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true
        };

        public static void Main(string[] args)
        {
            const string SOURCE_TOBY_EXPORTED_JSON = "/home/raven/Downloads/toby-export-sample.json";
            const string CONVERTED_RAINDROP_CSV = "/home/raven/Downloads/toby-export-sample.csv";
            var sourceTobyExportedJson= args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]) ? args[0] : SOURCE_TOBY_EXPORTED_JSON;
            var convertedRaindropCsv = args.Length > 1 && !string.IsNullOrWhiteSpace(args[1]) ? args[1] : CONVERTED_RAINDROP_CSV;

            var tobyJsonContent = File.ReadAllText(sourceTobyExportedJson);
            var tobyObject = JsonSerializer.Deserialize<TobyObject>(tobyJsonContent, jsonSerializerOptions);
            var rainDropCsv = tobyObject!.ToRainDropCsv();
          
            File.WriteAllLines(convertedRaindropCsv, rainDropCsv.GetCsvLines());
        }
    }
}