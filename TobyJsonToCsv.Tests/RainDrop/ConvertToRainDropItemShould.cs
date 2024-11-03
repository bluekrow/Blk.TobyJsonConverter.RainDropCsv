using FluentAssertions;
using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv.Tests.RainDrop;

public class ConvertToRainDropItemShould
{
    [Fact]
    public void GetJoinedTagsOnCsvLine()
    {
        var tobyCard = new TobyCard(
            "Inbox (693) - ndioses@voxelgroup.net",
            "https://mail.google.com/mail/u/0/#inbox",
            "mail",
            "inbox from vxl"
            );
        var tobyCollection = new TobyCollection("May 21 at 17:34",[tobyCard],["custom","work"]);

        var rainDropItem =tobyCard.ToRainDropItem(tobyCollection);

        const string EXPECTED_CSV_LINE = "https://mail.google.com/mail/u/0/#inbox, tobyImported/May 21 at 17:34, Inbox (693) - ndioses@voxelgroup.net, CustomTitle: mail|CustomDescription: inbox from vxl, #custom#work#2024-05-21, 2024-05-21T17:34:00";
        rainDropItem.GetCsvLine().Should().Be(EXPECTED_CSV_LINE);
    }
    
}