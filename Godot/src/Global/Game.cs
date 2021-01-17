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
    protected GameState state;
    protected List<Actor> players;
    protected InputState inputState;

    public Game(GameState state)
    {
      this.state = state;
      players = new List<Actor>();
      inputState = new InputState();
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