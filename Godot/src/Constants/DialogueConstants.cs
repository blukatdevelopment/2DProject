namespace Constants
{
  using Dialogue;
  using System.Collections.Generic;

  public class DialogueConstants
  {
    public const float DefaultDialogueDisplayTime = 1f;

    public static DialogueTree DebugDialogueTree()
    {
      DialogueTree tree = new DialogueTree();
      DialogueNode node1 = new DialogueNode(
        0,
        new DialogueMessage("Great job, Skippy!"),
        new List<DialogueOption>(){
            new DialogueOption(
              0,
              "Thanks",
              1)
          });

      DialogueNode node2 = new DialogueNode(
        1,
        new DialogueMessage("Keep up the good work!"),
        new List<DialogueOption>(){
            new DialogueOption(
              0,
              "[Continue]",
              -1)
          });

      tree.nodes.Add(node1);
      tree.nodes.Add(node2);

      return tree;
    }
  }
}