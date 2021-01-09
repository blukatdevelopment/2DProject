namespace Actor
{
  using System.Collections.Generic;
  using Godot;
  using Constants;
  using Input;

  public class Actor : Node2D, IActionSubscriber
  {
    private Sprite sprite;
    private Camera2D camera;
    private List<ActionEvent> actionEventsQueue;
    private float delay;


    public Actor()
    {
      delay = 0f;
      actionEventsQueue = new List<ActionEvent>();
      sprite = new Sprite();
      sprite.Texture = ResourceLoader.Load(ActorConstants.ActorTexture) as Texture;
      camera = new Camera2D();
      this.AddChild(sprite);
      this.AddChild(camera);
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

    private void Move(float x, float y)
    {
      GlobalPosition += new Vector2(x * ActorConstants.MovementSpeed, y * ActorConstants.MovementSpeed);
    }
  }
}