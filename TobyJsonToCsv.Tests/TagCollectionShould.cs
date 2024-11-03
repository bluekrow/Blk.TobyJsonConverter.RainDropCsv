using FluentAssertions;
using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv.Tests;

public class TagCollectionShould
{
    [Fact]
    public void PreserveAddingTagCompatibility()
    {
        var newTagCollection = new TagCollection();
        const string TAG1 = "one tag";
        const string TAG2 = "another tag";
        const string TAG3 = "even another tag";
        newTagCollection.AddTag(TAG1);
        newTagCollection.AddTag(TAG2);
        newTagCollection.AddTag(TAG3);
        var newAddingTagResult = newTagCollection.GetTags();

        var currentTagCollection = new TagCollection();
        var currentAddingTagResult = currentTagCollection.GetTags(new[] { TAG1, TAG2 }, TAG3);

        newAddingTagResult.Should().Be(currentAddingTagResult);
    }
}