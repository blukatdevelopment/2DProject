namespace Global {
  using Godot;
  using Actor;
  using Input;
  using System.Collections.Generic;

  // Yup, it's a moodel that holds game state.
  public class GameState : Node2D
  {
    public List<Actor> actors;
    public InputState inputState;

    public GameState()
    {
      actors = new List<Actor>();
      inputState = new InputState();
      AddChild(inputState);
    }

    public void AddActor(Actor actor)
    {
      actors.Add(actor);
      inputState.Subscribe(actor);
    }

    public void RemoveActor(Actor actor)
    {
      actors.Remove(actor);
      inputState.Unsubscribe(actor);
    }
  }
}