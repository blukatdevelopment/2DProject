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
    private int score = 0;

    public ShooterGame(GameState state) : base(state)
    {
    }

    public override void Start()
    {
      GD.Print("Shooter game started");
      Actor player = new Ship(new Vector2(10f, 10f), true, ShooterConstants.Up(), this);
      AddPlayer(player);
      this.AddChild(player);

      Actor enemy = new Ship(new Vector2(300f, 300f), false, ShooterConstants.Down(), this);
      this.AddChild(enemy);
    }

    public void CreateProjectile(Vector2 position, Vector2 direction)
    {
      GD.Print("Creating projectile at " + position + " moving " + direction);
      Actor projectile =  new Projectile(position, direction, this);
      this.AddChild(projectile);
    }

    public void ImpactShip(Ship ship)
    {
      RemovePlayer(ship);
      ship.QueueFree();
      if(players.Count == 0)
      {
        GameOver();
      }
      else
      {
        score++;
      }
    }

    private void GameOver()
    {
      GD.Print("Game Over");
    }

    public override void End()
    {
    }
  }
}