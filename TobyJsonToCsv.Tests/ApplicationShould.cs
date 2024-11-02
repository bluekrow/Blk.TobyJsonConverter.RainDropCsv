namespace TobyJsonToCsv.Tests;

public class ApplicationShould
{
    [Fact]
    public Task TemporarilyMaintainFailedExport()
    {
        Program.Main([]);
        return VerifyFile("/home/raven/Downloads/toby-export-sample.csv");
    }

    [Fact (Skip = "In progress goal")]
    public Task ConvertATobyJsonToRainDropCsv()
    {
        Program.Main([]);
        return VerifyFile("/home/raven/Downloads/toby-export-sample.csv");
    }
}