namespace TobyJsonToCsv.Tests;

public class ApplicationShould
{
    [Fact]
    public Task TemporarilyMaintainFailedExport()
    {
        Program.Main(default!);
        return VerifyFile("/home/raven/Downloads/toby-export-sample.csv");
    }

    [Fact (Skip = "In progress goal")]
    public Task ConvertATobyJsonToRainDropCsv()
    {
        Program.Main(default!);
        return VerifyFile("/home/raven/Downloads/toby-export-sample.csv");
    }
}