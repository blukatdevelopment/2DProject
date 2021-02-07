namespace Walker
{
  using Actor;
  using Input;
  using Godot;
  using Enums;
  using Global;
  using System.Collections.Generic;

  public class WalkerActor : Actor
  {
    public WalkerActor(Vector2 position, bool enableCamera ): base(position, enableCamera)
    {
    }

    public override void HandleAction(ActionEvent actionEvent)
    {
      if(!paused)
      {
        HandleMovement(actionEvent);
        HandleInteract(actionEvent);
      }
    }

    private void HandleInteract(ActionEvent actionEvent)
    {
      if(actionEvent.action != ActionEnum.Interact)
      {
        return;
      }
      Vector2 interactDirection = Utility.Vector2FromDirection(direction);
      GD.Print("Interact" + interactDirection);
      interactDirection *= 100f;
      Vector2 endPoint = (100f * interactDirection) + Position;
      List<object> ignored = new List<object>{ this };
      IInteractive interactive = Utility.RayCast(Position, endPoint, ignored, GetWorld2d()) as IInteractive;
      if(interactive != null)
      {
        interactive.Interact();
      }
    }
  }
}