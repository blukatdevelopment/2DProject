namespace Shooter
{
  using Godot;
  using Input;
  using Enums;
  using System.Collections.Generic;

  public class ShooterConstants
  {
    public static Vector2 Up()
    {
      return new Vector2(0f, -10f);
    }

    public static Vector2 Down()
    {
      return new Vector2(0f, 10f);
    }

    public static Vector2 ProjectileSize()
    {
      return new Vector2(10f, 10f);
    }

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
        new KeyMapping((int)KeyList.Space, InputModeEnum.PressStart, ActionEnum.FireStart),
        new KeyMapping((int)KeyList.Space, InputModeEnum.PressEnd, ActionEnum.FireEnd),
      };
    }
  }
}