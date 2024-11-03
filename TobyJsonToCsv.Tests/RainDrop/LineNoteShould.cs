using FluentAssertions;
using TobyJsonToCsv.RainDrop;

namespace TobyJsonToCsv.Tests.RainDrop;

public class LineNoteShould
{
    [Fact]
    public void GetANoteText()
    {
        var lineNote = new LineNote();
        lineNote.AddNotePart("notePart1", "notePartContent1");
        lineNote.AddNotePart("notePart2", "notePartContent2");
       
        var noteText = lineNote.GetNoteText();

        const string EXPECTED_NOTE_TEXT = "notePart1: notePartContent1|notePart2: notePartContent2";
        noteText.Should().Be(EXPECTED_NOTE_TEXT);
    }
}