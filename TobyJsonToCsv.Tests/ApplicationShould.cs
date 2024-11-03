namespace TobyJsonToCsv.Tests;

public class ApplicationShould
{
    [Fact]
    public Task ConvertATobyJsonToRainDropCsv()
    {
        const string SOURCE_TOBY_EXPORTED_JSON = "Resources/sourceTobyExported.json";
        const string RAINDROP_CONVERTED_CSV = "Resources/rainDropConverted.csv";

        var programArguments = new[]
        {
            SOURCE_TOBY_EXPORTED_JSON,
            RAINDROP_CONVERTED_CSV
        };

        Program.Main(programArguments);
        return VerifyFile(RAINDROP_CONVERTED_CSV);
    }
}