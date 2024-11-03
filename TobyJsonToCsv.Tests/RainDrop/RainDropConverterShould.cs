using System.Text.Json;
using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv.Tests.RainDrop;

public class RainDropConverterShould
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        IncludeFields = true,
        PropertyNameCaseInsensitive = true
    };
    
    [Fact]
    public Task ProduceRainDropCsvLines()
    {
        var sourceTobyExportedText = File.ReadAllText("Resources/sourceTobyExported.json");
        var tobyObject = JsonSerializer.Deserialize<TobyObject>(sourceTobyExportedText, jsonSerializerOptions);
        var convertedRainDropActualLines = tobyObject!.ToRainDropCsv().GetCsvLines();
        return Verify(convertedRainDropActualLines);
    }   
}