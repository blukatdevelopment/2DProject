namespace Shooter
{
  using Godot;
  using System;
  using Constants;

  public class EnemySpawner : Node2D
  {
    private ShooterGame game;
    private int enemyCount = 0;
    private bool spawnActive;
    private float timeSinceSpawn = 0f;
    private float nextSpawnDelay = 0f;
    private Random random;
    private bool paused;

    public EnemySpawner(ShooterGame game)
    {
      this.game = game;
      this.random = new Random();
    }

    public void StartWave(int enemyCount)
    {
      this.enemyCount = enemyCount;
      this.spawnActive = true;
    }

    public override void _Process(float delta)
    {
      if(!spawnActive || paused)
      {
        return;
      }

      timeSinceSpawn += delta;
      if(timeSinceSpawn >= nextSpawnDelay)
      {
        SpawnRandomEnemy();
        enemyCount--;
        timeSinceSpawn = 0f;
        nextSpawnDelay = (float)(random.NextDouble() * ShooterConstants.MaxEnemySpawnTime);
        if(enemyCount < 1)
        {
          spawnActive = false;
        }
      }
    }

    public void Pause()
    {
      paused = true;
    }

    public void Resume()
    {
      paused = false;
    }

    private void SpawnRandomEnemy()
    {
      game.SpawnEnemy(RandomSpawnPoint());
    }

    private Vector2 RandomSpawnPoint()
    {
      Vector2 size = ShooterConstants.ShipSize(); 
      float y = size.y;

      int minX = (int)size.x;
      int maxX = (int)(GameConstants.GameResolution().x-size.x);
      float x = random.Next(minX, maxX);
      return new Vector2(x, y);
    }
  }
}