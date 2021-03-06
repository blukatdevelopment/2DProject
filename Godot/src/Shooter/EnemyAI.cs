namespace Shooter
{
  using System;
  using Godot;
  using Input;
  using Enums;
  using System.Collections.Generic;

  public class EnemyAI
  {
    private List<Ship> enemies;
    private World2D world;
    private bool paused;

    public EnemyAI(World2D world)
    {
      this.world = world;
      enemies = new List<Ship>();
    }

    public void Update()
    {
      if(paused)
      {
        return;
      }

      foreach(Ship enemy in enemies)
      {
        UpdateEnemy(enemy);
      }
    }

    public void RemoveEnemy(Ship enemy)
    {
      enemies.Remove(enemy);
    }

    public void AddEnemy(Ship enemy)
    {
      enemy.movementSpeed = ShooterConstants.ShipSpeed / 5f;
      enemies.Add(enemy);
    }

    private void UpdateEnemy(Ship ship)
    {
      QueueAction(ship, ActionEnum.MoveDownStart);
    }

    public void Pause()
    {
      paused = true;
      foreach(Ship enemy in enemies)
      {
        enemy.Pause();
      }
    }

    public void Resume()
    {
      paused = false;
      foreach(Ship enemy in enemies)
      {
        enemy.Resume();
      }
    }

    private object RayCast(Vector2 start, Vector2 end)
    {
      Physics2DDirectSpaceState spaceState = world.DirectSpaceState;
      var result = spaceState.IntersectRay(start, end);
      return result["collider"];
    }

    private void QueueAction(Ship ship, ActionEnum action)
    {
      ship.QueueActions(new List<ActionEvent>{ new ActionEvent(action) });
    }
  }
}