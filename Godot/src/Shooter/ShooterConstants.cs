namespace Shooter
{
  using Godot;
  using Input;
  using Enums;
  using Constants;
  using System.Collections.Generic;

  public class ShooterConstants
  {
    public const float ProjectileSpeed = 75f;
    public const float ShipSpeed = 25f;

    public static Vector2 VerticalBoundarySize()
    {
      return new Vector2(50f, GameConstants.GameResolution().y);
    }

    public static Vector2 HorizontalBoundarySize()
    {
      return new Vector2(GameConstants.GameResolution().x, 50f);
    }

    public static RectangleShape2D ShipShape()
    {
      RectangleShape2D shape = new RectangleShape2D();
      shape.Extents = ShipSize()/2f;
      return shape;
    }

    public static Vector2 ShipSize()
    {
      return new Vector2(50f, 50f);
    }

    public static Vector2 ProjectileSize()
    {
      return new Vector2(10f, 10f);
    }

    public static Vector2 Up()
    {
      return new Vector2(0f, -50f);
    }

    public static Vector2 Down()
    {
      return new Vector2(0f, 50f);
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