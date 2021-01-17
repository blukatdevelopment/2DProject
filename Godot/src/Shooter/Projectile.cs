namespace Shooter
{
  using Global;
  using Godot;
  using Actor;
  using Input;
  using Constants;
  using System.Collections.Generic;

  public class Projectile : Actor
  {
    private ShooterGame game;

    public Projectile(Vector2 position, Vector2 direction, ShooterGame game)
    {
      this.movement = direction;
      this.game = game;
      this.Position = position;
      Vector2 size = ShooterConstants.ProjectileSize();

      sprite = new Sprite();
      Texture texture = ResourceLoader.Load(ActorConstants.ActorTexture) as Texture;
      SetSpriteTexture(texture, size);
      this.AddChild(sprite);

      delay = 0f;
      actionEventsQueue = new List<ActionEvent>();
      collider = new CollisionShape2D();
      RectangleShape2D shape = new RectangleShape2D();
      shape.Extents = size/2f;
      collider.Shape = shape;
      this.AddChild(collider);
    }

    public override void HandleAction(ActionEvent actionEvent)
    {
      HandleMovement(actionEvent);
    }

    public override void OnCollide(KinematicCollision2D collision)
    {
      Ship ship = collision.Collider as Ship;
      if(ship != null)
      {
        game.ImpactShip(ship);
        this.QueueFree();
      }
    }
  }
}