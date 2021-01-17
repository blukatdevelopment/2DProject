namespace Shooter
{
  using Global;
  using Godot;
  using Actor;
  using Input;
  using Enums;
  using Constants;
  using System.Collections.Generic;

  public class Ship : Actor
  {
    private Vector2 fireDirection;
    private ShooterGame game;

    public Ship(Vector2 position, bool enableCamera, Vector2 fireDirection, ShooterGame game)
    {
      this.fireDirection = fireDirection;
      this.game = game;

      this.Position = position;

      if(enableCamera)
      {
        camera = new Camera2D();
        camera.Current = true;
        this.AddChild(camera);
      }

      sprite = new Sprite();
      Texture texture = ResourceLoader.Load(ActorConstants.ActorTexture) as Texture;
      SetSpriteTexture(texture, ShooterConstants.ShipSize());
      this.AddChild(sprite);

      delay = 0f;
      actionEventsQueue = new List<ActionEvent>();
      collider = new CollisionShape2D();
      collider.Shape = ShooterConstants.ShipShape();
      this.AddChild(collider);
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