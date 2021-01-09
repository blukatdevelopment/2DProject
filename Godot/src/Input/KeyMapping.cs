namespace Input
{
  using Enums;
  using System.Collections.Generic;
  using Input;
  using Godot;
  using Constants;

  // Maps a specific key to a specific action and contains data used to determine if a trigger has been reached
  public class KeyMapping
  {
    public int key;
    public InputModeEnum mode;
    public ActionEnum action;

    public bool wasDown;
    public bool isDown;
    public float downDuration;


    public KeyMapping(int key, InputModeEnum mode, ActionEnum action)
    {
      this.key = key;
      this.mode = mode;
      this.action = action;
    }

    public List<ActionEvent> GetEvents(float delta)
    {
      Update(delta);
      switch(mode)
      {
        case InputModeEnum.PressStart:
          if(IsPressStartTriggered())
          {
            return new List<ActionEvent>{ new ActionEvent(action) };
          }
        break;
        case InputModeEnum.PressEnd:
          if(IsPressEndTriggered())
          {
            return new List<ActionEvent>{ new ActionEvent(action) };
          }
        break;
      }
      return new List<ActionEvent>();
    }

    private bool IsPressStartTriggered()
    {
      return isDown && !wasDown;
    }

    private bool IsPressEndTriggered()
    {
      return downDuration < InputConstants.LongPressDuration && wasDown && !isDown;
    }

    private void Update(float delta)
    {
      wasDown = isDown;
      isDown = Input.IsKeyPressed(key);
      if(!isDown && wasDown)
      {
        downDuration = 0f;
      }
      else
      {
        downDuration += delta;
      }
    }
  }
}