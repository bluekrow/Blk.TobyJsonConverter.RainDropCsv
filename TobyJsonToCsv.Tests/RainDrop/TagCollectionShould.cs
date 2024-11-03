using FluentAssertions;
using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv.Tests.RainDrop;

public class TagCollectionShould
{
    [Fact]
    public void GetAJoinedTagString()
    {
        var tagCollection = new TagCollection();
        const string TAG1 = "one tag";
        const string TAG2 = "another tag";
        const string TAG3 = "even another tag";
        tagCollection.AddTags([TAG1,TAG2]);
        tagCollection.AddTag(TAG3);
        
        var tagString = tagCollection.GetTags();
        
        tagString.Should().Be("#one tag#another tag#even another tag");
    }
    
    [Fact]
    public void CleanEmptyTagsOnTagString()
    {
        var tagCollection = new TagCollection();
        const string TAG1 = "one tag";
        const string TAG2 = "even another tag";
        tagCollection.AddTags([TAG1,string.Empty]);
        tagCollection.AddTag(TAG2);
        
        var tagString = tagCollection.GetTags();
        
        tagString.Should().Be("#one tag#even another tag");
    }

}