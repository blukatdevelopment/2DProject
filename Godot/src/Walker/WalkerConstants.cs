namespace Walker
{
  using Input;
  using Enums;
  using Godot;
  using System.Collections.Generic;

  public class WalkerConstants
  {
    public static List<KeyMapping> PlayerControls()
    {
      return new List<KeyMapping>
      {
        new KeyMapping((int)KeyList.Up, InputModeEnum.PressStart, ActionEnum.MoveUpStart),
        new KeyMapping((int)KeyList.Up, InputModeEnum.PressEnd, ActionEnum.MoveUpEnd),
        new KeyMapping((int)KeyList.Down, InputModeEnum.PressStart, ActionEnum.MoveDownStart),
        new KeyMapping((int)KeyList.Down, InputModeEnum.PressEnd, ActionEnum.MoveDownEnd),
        new KeyMapping((int)KeyList.Right, InputModeEnum.PressStart, ActionEnum.MoveRightStart),
        new KeyMapping((int)KeyList.Right, InputModeEnum.PressEnd, ActionEnum.MoveRightEnd),
        new KeyMapping((int)KeyList.Left, InputModeEnum.PressStart, ActionEnum.MoveLeftStart),
        new KeyMapping((int)KeyList.Left, InputModeEnum.PressEnd, ActionEnum.MoveLeftEnd),
        new KeyMapping((int)KeyList.Space, InputModeEnum.PressStart, ActionEnum.Interact)
      };
    }
  }
}