namespace Actor
{
  using Enums;
  using Constants;
  using Godot;
  using Input;

  public class PlayerActor : Actor
  {
    public PlayerActor(Vector2 position) : base(position, true)
    {
      movement = new Vector2();
    }

    public override void HandleAction(ActionEvent actionEvent)
    {
      HandleMovement(actionEvent);
    }

    public override void PostEventsUpdate()
    {
      Move(movement);
    }
  }
}