namespace Dialogue
{
  using System.Collections.Generic;

  // Holds info needed to display a single dialogue message onto the screen.
  public class DialogueNode
  {
    public int id;
    public DialogueMessage message;
    public List<DialogueOption> options;

    public DialogueNode()
    {
      id = -1;
      message = null;
      options = new List<DialogueOption>();
    }

    public DialogueNode(int id, DialogueMessage message, List<DialogueOption> options)
    {
      this.id = id;
      this.message = message;
      this.options = options;
    }

    public DialogueNode(DialogueMessage message)
    {
      this.id = -1;
      this.message = message;
      this.options = new List<DialogueOption>();
    }

    public DialogueOption GetOption(int optionId)
    {
      foreach(DialogueOption option in options)
      {
        if(option.optionId == optionId)
        {
          return option;
        }
      }
      return null;
    }

    public bool HasNoOptions()
    {
      return options.Count == 0;
    }
  }
}