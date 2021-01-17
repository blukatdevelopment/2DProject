namespace Shooter
{
  using Global;
  using Godot;
  using Actor;
  using Input;
  using System.Collections.Generic;
  using Constants;

  /*
    Enemies move downward from the top of the screen.
    you move around and fire projectiles at them.
  */
  public class ShooterGame : Game
  {
    private int score = 0;
    private Camera2D camera;

    public ShooterGame()
    {
    }

    public ShooterGame(GameState state)
    {
      this.gameState = state;
      players = new List<Actor>();
      this.inputState = new InputState(ShooterConstants.PlayerControls());
      AddChild(this.inputState);
    }

    public override void Start()
    {
      GD.Print("Shooter game started");
      
      InitCamera();

      SpawnPlayer();

      SpawnEnemyWave();
    }

    private void SpawnPlayer()
    {
      float x = GameConstants.GameResolution().x/2f;
      float y = GameConstants.GameResolution().y - ShooterConstants.ShipSize().y;
      Actor player = new Ship(new Vector2(x, y), false, ShooterConstants.Up(), this);
      AddPlayer(player);
      this.AddChild(player);
    }

    private void SpawnEnemyWave()
    {
      Vector2 max = GameConstants.GameResolution();
      Vector2 shipSize = ShooterConstants.ShipSize();
      for(float screenPosX = shipSize.x; screenPosX < max.x; screenPosX += shipSize.x * 2f)
      {
        for(float screenPosY = shipSize.y; screenPosY < max.y/5f; screenPosY += shipSize.y * 2f)
        {
          GD.Print("Placing enemy at " + screenPosX + "," + screenPosY);
          Actor enemy = new Ship(new Vector2(screenPosX, screenPosY), false, ShooterConstants.Down(), this);
          this.AddChild(enemy);
        }
      }
    }

    private void InitCamera()
    {
      camera = new Camera2D();
      camera.Current = true;
      camera.AnchorMode = Camera2D.AnchorModeEnum.FixedTopLeft;
      Viewport viewport = this.GetViewport();
      viewport.SetSizeOverrideStretch(true);
      viewport.Size = GameConstants.GameResolution();
      AddChild(camera);
    }

    public void CreateProjectile(Vector2 position, Vector2 direction)
    {
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
