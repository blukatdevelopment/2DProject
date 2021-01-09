namespace Input
{
  using Godot;
  using Constants;
  using Enums;
  using System.Collections.Generic;

  public class InputState : Node2D
  {
    List<IActionSubscriber> subscribers;
    List<KeyMapping> keyMappings;

    public InputState()
    {
      keyMappings = InputConstants.GetKeyMappings();
      subscribers = new List<IActionSubscriber>();
    }

    public override void _Process(float delta)
    {
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