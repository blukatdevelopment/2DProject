namespace Input
{
  using Godot;
  using Constants;
  using Enums;
  using System.Collections.Generic;

  public class InputState : Node2D
  {
    private List<IActionSubscriber> subscribers;
    private List<KeyMapping> keyMappings;
    private bool paused;

    public InputState(bool paused = false)
    {
      this.paused = paused;
      keyMappings = InputConstants.GetKeyMappings();
      subscribers = new List<IActionSubscriber>();
    }

    public override void _Process(float delta)
    {
      if(paused)
      {
        return;
      }

      List<ActionEvent> actionEvents = new List<ActionEvent>();
      foreach(KeyMapping keyMapping in keyMappings)
      {
        actionEvents.AddRange(keyMapping.GetEvents(delta));
      }

      foreach(IActionSubscriber subscriber in subscribers)
      {
        subscriber.QueueActions(actionEvents);
      }
    }

    public void Pause()
    {
      paused = true;
    }

    public void Resume()
    {
      paused = false;
    }

    public void Subscribe(IActionSubscriber subscriber)
    {
      subscribers.Add(subscriber);
    }

    public void Unsubscribe(IActionSubscriber subscriber)
    {
      subscribers.Remove(subscriber);
    }
  }
}