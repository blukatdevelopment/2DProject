namespace Shooter
{
  using Global;
  using Godot;
  using Actor;
  using Input;
  using Dialogue;
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
    private EnemyAI enemyAI;
    private float timeSinceAIUpdate = 0f;
    private EnemySpawner spawner;

    public ShooterGame()
    {
    }

    public ShooterGame(GameState state) : base()
    {
      this.gameState = state;
      players = new List<Actor>();
      this.inputState = new InputState(ShooterConstants.PlayerControls());
      AddChild(this.inputState);
      this.spawner = new EnemySpawner(this);
      AddChild(this.spawner);
    }

    public override void Start()
    {
      GD.Print("Shooter game started");
      
      enemyAI = new EnemyAI(GetWorld2d());

      InitCamera();

      InitBoundaries();

      SpawnPlayer();

      this.spawner.StartWave(ShooterConstants.EnemiesInWave);
    }

    public override void Pause()
    {
      inputState.Pause();
      spawner.Pause();
      enemyAI.Pause();
    }

    public override void Resume()
    {
      inputState.Resume();
      spawner.Resume();
      enemyAI.Resume();
    }

    private void InitBoundaries()
    {
      Vector2 resolution = GameConstants.GameResolution();
      Vector2 verticalSize = ShooterConstants.VerticalBoundarySize();
      Vector2 horizontalSize = ShooterConstants.HorizontalBoundarySize();
      
      KinematicBody2D leftBoundary = CreateBoundary(
        new Vector2(verticalSize.x/-2f, resolution.y/2f),
        verticalSize);
      AddChild(leftBoundary);

      KinematicBody2D rightBoundary = CreateBoundary(
        new Vector2(verticalSize.x/2f + resolution.x, resolution.y/2f),
        verticalSize);
      AddChild(rightBoundary);

      KinematicBody2D topBoundary = CreateBoundary(
        new Vector2(resolution.x/2f, horizontalSize.y/-2f),
        horizontalSize);
      AddChild(topBoundary);

      KinematicBody2D bottomBoundary = CreateBoundary(
        new Vector2(resolution.x/2f, resolution.y + horizontalSize.y/2f),
        horizontalSize);
      AddChild(bottomBoundary);
    }

    private KinematicBody2D CreateBoundary(Vector2 position, Vector2 size)
    {
      KinematicBody2D boundary = new KinematicBody2D();
      CollisionShape2D collider = new CollisionShape2D();
      RectangleShape2D shape = new RectangleShape2D();
      shape.Extents = size/2f;
      collider.Shape = shape;
      boundary.AddChild(collider);
      boundary.Position = position;
      return boundary;
    }

    private void SpawnPlayer()
    {
      float x = GameConstants.GameResolution().x/2f;
      float y = GameConstants.GameResolution().y - ShooterConstants.ShipSize().y;
      Actor player = new Ship(new Vector2(x, y), false, ShooterConstants.Up(), this);
      AddPlayer(player);
      AddChild(player);
    }

    public void SpawnEnemy(Vector2 position)
    {
      Actor enemy = new Ship(position, false, ShooterConstants.Down(), this);
      enemyAI.AddEnemy(enemy as Ship);
      AddChild(enemy);
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

    public override void _Process(float delta)
    {
      timeSinceAIUpdate += delta;
      if(timeSinceAIUpdate >= ShooterConstants.AIUpdateDelay)
      {
        enemyAI.Update();
      }
    }

    public void CreateProjectile(Vector2 position, Vector2 direction)
    {
      Actor projectile =  new Projectile(position, direction, this);
      this.AddChild(projectile);
    }

    public void ImpactShip(Ship ship)
    {
      RemovePlayer(ship);
      enemyAI.RemoveEnemy(ship);
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
