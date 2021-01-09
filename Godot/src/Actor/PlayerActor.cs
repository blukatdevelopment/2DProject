namespace Actor
{
  using Enums;
  using Constants;
  using Godot;
  using Input;

  public class PlayerActor : Actor
  {
    Vector2 movement;

    public PlayerActor() : base()
    {
      movement = new Vector2();
    }

    public override void HandleAction(ActionEvent actionEvent)
    {
      switch(actionEvent.action)
      {
        case ActionEnum.MoveUpStart:
          movement += new Vector2(0f, -ActorConstants.MovementSpeed);
        break;
        case ActionEnum.MoveUpEnd:
          movement += new Vector2(0f, ActorConstants.MovementSpeed);
        break;
        case ActionEnum.MoveDownStart:
          movement += new Vector2(0f, ActorConstants.MovementSpeed);
        break;
        case ActionEnum.MoveDownEnd:
          movement += new Vector2(0f, -ActorConstants.MovementSpeed);
        break;
        case ActionEnum.MoveRightStart:
          movement += new Vector2(ActorConstants.MovementSpeed, 0f);
        break;
        case ActionEnum.MoveRightEnd:
          movement += new Vector2(-ActorConstants.MovementSpeed, 0f);
        break;
        case ActionEnum.MoveLeftStart:
          movement += new Vector2(-ActorConstants.MovementSpeed, 0f);
        break;
        case ActionEnum.MoveLeftEnd:
          movement += new Vector2(ActorConstants.MovementSpeed, 0f);
        break;
      }
    }

    public override void PostEventsUpdate()
    {
      Position += movement;
    }
  }
}