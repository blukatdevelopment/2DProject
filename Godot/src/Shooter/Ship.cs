namespace Shooter
{
  using Global;
  using Godot;
  using Actor;
  using Input;
  using Enums;
  using Constants;

  public class Ship : Actor
  {
    private Vector2 fireDirection;
    private ShooterGame game;

    public Ship(Vector2 pos, bool enableCamera, Vector2 fireDirection, ShooterGame game) : base(pos, enableCamera)
    {
      this.fireDirection = fireDirection;
      this.game = game;
    }

    public override void HandleAction(ActionEvent actionEvent)
    {
      HandleMovement(actionEvent);
      HandleFire(actionEvent);
    }

    private void HandleFire(ActionEvent actionEvent)
    {
      if(actionEvent.action != ActionEnum.FireStart)
      {
        return;
      }
      Vector2 projectilePosition = Position;
      if(fireDirection.y < 0)
      {
        projectilePosition.y -= ActorConstants.DefaultHeight;
      }
      else
      {
        projectilePosition.y += ActorConstants.DefaultHeight;
      }
      game.CreateProjectile(projectilePosition, fireDirection);
    }

    public override void OnCollide(KinematicCollision2D collision)
    {
      Ship ship = collision.Collider as Ship;
      if(ship != null)
      {
        game.ImpactShip(ship);
        game.ImpactShip(this);
      }
    }
  }
}