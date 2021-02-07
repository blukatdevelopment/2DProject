namespace Global
{
  using Godot;
  using Actor;
  using System.Collections.Generic;
  using Input;

  /*
    Runs a self-contained game using a GameState object
  */
  public class Game : Node2D
  {

    protected GameState gameState;
    protected List<Actor> players;
    protected InputState inputState;

    public Game()
    {
      players = new List<Actor>();
    }

    public Game(GameState gameState, InputState inputState)
    {
      this.gameState = gameState;
      players = new List<Actor>();
      this.inputState = inputState;
      AddChild(inputState);
    }

    public virtual void Start()
    {
    }

    public virtual void Pause()
    {
      inputState.Pause();
    }

    public virtual void Resume()
    {
      inputState.Resume();
    }

    public virtual void End()
    {
    }

    public void AddPlayer(Actor actor)
    {
      players.Add(actor);
      inputState.Subscribe(actor);
    }

    public void RemovePlayer(Actor actor)
    {
      players.Remove(actor);
      inputState.Unsubscribe(actor);
    }

  }
}
