namespace Shooter
{
  using Global;
  using Godot;
  using Actor;

  /*
    Enemies move downward from the top of the screen.
    you move around and fire projectiles at them.
  */
  public class ShooterGame : Game
  {
    public ShooterGame(GameState state) : base(state)
    {
    }

    public override void Start()
    {
      GD.Print("Shooter game started");
      Actor player = new PlayerActor(new Vector2(10f, 10f));
      AddActor(player);
      this.AddChild(player);

      Actor enemy = new Actor(new Vector2(300f, 300f));
      this.AddChild(enemy);
    }

    public override void End()
    {

    }
  }
}