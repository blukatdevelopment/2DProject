namespace Shooter
{
  using Godot;

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
  }
}