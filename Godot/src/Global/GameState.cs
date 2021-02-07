namespace Global {
  using Godot;
  using Actor;
  using Input;
  using System.Collections.Generic;
  using Dialogue;
  using Walker;

  /*
    Yup, it's a model that holds shared data used by the Game class.
    Only this object should need to be persisted for a particular
    session to be persisted.
    If a particular game needs a ton more granular data, an object
    containing that data can be added inside here to contain it.
  */
  public class GameState : Node2D
  {
    public int lives = 1;
    public WalkerState walkerState;
    public Vector2 dialoguePosition;

    public GameState()
    {
      walkerState = new WalkerState();
    }
  }
}