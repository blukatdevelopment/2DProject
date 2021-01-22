namespace Dialogue
{
  public class DialogueOption
  {
    public int optionId;
    public string displayText;
    public int destinationNode;

    public DialogueOption()
    {
    }

    public DialogueOption(int optionId, string displayText, int destinationNode)
    {
      this.optionId = optionId;
      this.displayText = displayText;
      this.destinationNode = destinationNode;
    }
  }
}