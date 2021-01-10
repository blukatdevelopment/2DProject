/*
  Just a god object. Nothing to see here, people.
*/
namespace Global {
  using Godot;
  using Actor;
  public class Session : Node2D
  {
    // Is that a naive singleton? You can bet your britches it is!
    public static Session session;
    public GameState state;

    public override void _Ready()
    {
      EnforceSingleton();
      state = new GameState();
      AddChild(state);
      GD.Print("Session initialized");
      StartNewGame();
    }

    private void EnforceSingleton()
    {
      if(Session.session == null)
      {
        Session.session = this;
      }
      else
      {
        this.QueueFree();
      }
    }

    private void StartNewGame()
    {
      Actor player = new PlayerActor(new Vector2(10f, 10f));
      state.AddActor(player);
      this.AddChild(player);

      Actor enemy = new EnemyActor(new Vector2(300f, 300f));
      this.AddChild(enemy);
    }
  }
}
