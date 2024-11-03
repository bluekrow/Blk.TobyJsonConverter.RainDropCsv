using FluentAssertions;
using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv.Tests.RainDrop;

public class LineNoteShould
{
    [Fact]
    public void ProduceNoteTextWithCurrentAndNewMethods()
    {
        var currentLineNote = new LineNote();
        var currentLineNoteContent = currentLineNote.GetNote(
                new KeyValuePair<string, string>("notePart1", "notePartContent1"),
                new KeyValuePair<string, string>("notePart2", "notePartContent2")
        );

        var newLineNote = new LineNote();
        newLineNote.AddNotePart("notePart1", "notePartContent1");
        newLineNote.AddNotePart("notePart2", "notePartContent2");
        var newLineNoteContent = newLineNote.GetNote();
        
        currentLineNoteContent.Should().Be(newLineNoteContent);
    }
}