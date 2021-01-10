namespace Constants
{
  using Godot;

  public class ActorConstants
  {
    public const string ActorTexture = "res://Textures/Actors/Actor.jpg";

    public const float MovementSpeed = 10f;

    public const float ActionHandlingDelay = 0.03f;

    public const float DefaultWidth = 100f;

    public const float DefaultHeight = 100f;

    public static RectangleShape2D DefaultShape()
    {
      RectangleShape2D shape = new RectangleShape2D();
      shape.Extents = new Vector2(DefaultWidth/2f, DefaultHeight/2f);
      return shape;
    }
  }
}