namespace Walker
{
  using Godot;
  using Dialogue;
  using Constants;
  using Global;
  
  public class TeleportationObject : Area2D, IInteractive
  {
    [Export]
    public string DestinationMap { get; set; }

    [Export]
    public Vector2 PlayerSpawnPoint { get; set; }

    public override void _Ready()
    {
      GD.Print("_Ready");
      Connect("body_entered", this, nameof(OnBodyEntered));
    }

    public void Interact()
    {
      WalkerGame.LoadMap(DestinationMap, PlayerSpawnPoint);
    }

    public void OnBodyEntered(Object body)
    {
      WalkerActor player = body as WalkerActor;
      if(player != null)
      {
        Interact();
      }
    }
  }
}
