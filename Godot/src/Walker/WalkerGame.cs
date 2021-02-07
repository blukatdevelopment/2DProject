namespace Walker
{
  using Global;
  using Godot;
  using Enums;
  using Actor;
  using Input;
  using Constants;

  /*
    A game where you walk around a map and interact with interactive objects.
    Set gameState.walkerState.activeScene to start it
  */
  public class WalkerGame : Game
  {
    public WalkerState walkerState;
    public GameState gamestate;
    public Node2D activeScene;
    public Actor player;
    public DirectionEnum direction;

    public WalkerGame(GameState gameState)
    {
      this.gameState = gamestate;
      walkerState = gameState.walkerState;
      gameState.dialoguePosition = new Vector2(-400, -400);
    }

    public static void LoadMap(string scenePath, Vector2 position)
    {
      Session.session.state.walkerState.activeScene = scenePath;
      Session.session.state.walkerState.playerSpawnPoint = position;
      Session.session.StartNewGame(GameTypeEnum.Walker);
    }

    public override void Start()
    {
      GD.Print("Loading scene " + walkerState.activeScene);
      PackedScene packedScene = (PackedScene)ResourceLoader.Load(walkerState.activeScene);
      activeScene = (Node2D)packedScene.Instance();
      AddChild(activeScene);

      inputState = new InputState(WalkerConstants.PlayerControls());
      AddChild(inputState);

      player = new WalkerActor(walkerState.playerSpawnPoint, true);
      AddPlayer(player);
      AddChild(player);
    } 
  }
}