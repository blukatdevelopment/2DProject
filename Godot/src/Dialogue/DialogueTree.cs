namespace Dialogue
{
  using System;
  using System.Collections.Generic;
  using Godot;

  public class DialogueTree
  {
    public List<DialogueNode> nodes;
    public int activeNode;
    
    public DialogueTree()
    {
      activeNode = 0;
      nodes = new List<DialogueNode>();
    }

    public DialogueTree(List<DialogueNode> nodes)
    {
      this.nodes = nodes;
      activeNode = 0;
    }

    public DialogueTree(DialogueNode node)
    {
      this.nodes = new List<DialogueNode>{ node };
      activeNode = node.id;
    }

    public DialogueTree(string displayText)
    {
      this.nodes = new List<DialogueNode>
      {
        new DialogueNode(new DialogueMessage(displayText))
      };
      activeNode = nodes[0].id;
    }

    public DialogueNode GetActiveNode(){
      return GetNode(activeNode);
    }

    public DialogueNode GetNode(int id)
    {
      foreach(DialogueNode node in nodes)
      {
        if(node.id == id)
        {
          return node;
        }
      }
      return null;
    }
  }
}
