namespace Dialogue
{
  // One segment of text displayed on the screen.
  public class DialogueMessage
  {
    public string speaker;
    public string displayText;

    public DialogueMessage()
    {
    }

    public DialogueMessage(string displayText)
    {
      this.displayText = displayText;
    }

    public DialogueMessage(string displayText, string speaker)
    {

    }
  }
}