namespace Actor
{
  using System.Collections.Generic;
  using Godot;
  using Constants;
  using Input;

  public class Actor : KinematicBody2D, IActionSubscriber
  {
    protected Sprite sprite;
    protected Camera2D camera;
    protected List<ActionEvent> actionEventsQueue;
    protected float delay;
    protected CollisionShape2D collider;

    public Actor(Vector2 position, bool enableCamera = false)
    {
      this.Position = position;

      if(enableCamera)
      {
        camera = new Camera2D();
        camera.Current = true;
        this.AddChild(camera);
      }

      sprite = new Sprite();
      Texture texture = ResourceLoader.Load(ActorConstants.ActorTexture) as Texture;
      SetSpriteTexture(texture, new Vector2(ActorConstants.DefaultWidth, ActorConstants.DefaultHeight));
      this.AddChild(sprite);

      delay = 0f;
      actionEventsQueue = new List<ActionEvent>();
      collider = new CollisionShape2D();
      collider.Shape = ActorConstants.DefaultShape();
      this.AddChild(collider);

    }

    public void QueueActions(List<ActionEvent> actionEvents)
    {
      actionEventsQueue.AddRange(actionEvents);
    }

    public override void _Process(float delta)
    {
      delay += delta;
      if(delay >= ActorConstants.ActionHandlingDelay)
      {
        delay = 0f;
        foreach(ActionEvent actionEvent in actionEventsQueue)
        {
          HandleAction(actionEvent);
        }
        actionEventsQueue = new List<ActionEvent>();
        PostEventsUpdate();
      }
    }

    public virtual void HandleAction(ActionEvent actionEvent)
    {
      GD.Print("Handling " + actionEvent.action);
    }

    public virtual void PostEventsUpdate()
    {
    }

    public virtual void OnCollide(KinematicCollision2D collision)
    {

    }

    protected void SetSpriteTexture(Texture texture, Vector2 size)
    {
      Vector2 textureSize = texture.GetSize();
      Vector2 scale = size/textureSize;
      sprite.Texture = texture;
      sprite.Scale = scale;
    }

    protected void Move(Vector2 movement)
    {
      KinematicCollision2D collision = MoveAndCollide(movement);
      if(collision != null && collision.Collider != null)
      {
        OnCollide(collision);
      }
    }
  }
}
