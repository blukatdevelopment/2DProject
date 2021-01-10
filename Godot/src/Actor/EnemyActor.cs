namespace Actor
{
  using Enums;
  using Constants;
  using Godot;
  using Input;

  public class EnemyActor : Actor
  {
    Vector2 movement;

    public EnemyActor(Vector2 position) : base(position)
    {
      movement = new Vector2();
    }

    public override void HandleAction(ActionEvent actionEvent)
    {
    }

    public override void PostEventsUpdate()
    {
    }
  }
}