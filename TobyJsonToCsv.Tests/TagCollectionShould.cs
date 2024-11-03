using FluentAssertions;
using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv.Tests;

public class TagCollectionShould
{
    [Fact]
    public void GetAJoinedTagString()
    {
        var newTagCollection = new TagCollection();
        const string TAG1 = "one tag";
        const string TAG2 = "another tag";
        const string TAG3 = "even another tag";
        newTagCollection.AddTags([TAG1,TAG2]);
        newTagCollection.AddTag(TAG3);
        
        var newAddingTagResult = newTagCollection.GetTags();
        
        newAddingTagResult.Should().Be("#one tag#another tag#even another tag");
    }
}