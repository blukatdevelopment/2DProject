namespace Walker
{
  using Godot;
  using Dialogue;
  using Constants;
  using Global;

  // When you interact with this object, it displays a dialogue message
  public class DialogueObject: KinematicBody2D, IInteractive
  {
    [Export]
    public string DialogueTree { get; set; }

    [Export]
    public int DialogueNodeId { get; set; }

    public void Interact()
    {
      GD.Print("Display dialogue tree:" + DialogueTree);
      Session.session.dialogue.Activate(DialogueTree, DialogueNodeId);
    }
  }
}
