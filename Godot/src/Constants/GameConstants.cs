namespace Constants
{
  using Global;
  using Enums;
  using Godot;
  using Shooter;
  using Input;

  public class GameConstants
  {
    public static GameState DefaultGameState()
    {
      GameState state = new GameState();
      state.lives = 3;
      return state;
    }

    public static Game NewGameByType(GameTypeEnum gameType, GameState state)
    {
      switch(gameType)
      {
        case GameTypeEnum.Shooter:
          return new ShooterGame(state);
        default:
          GD.Print("NewGameByType: invalid gameType: " + gameType);
          return null;
      }
    }

    public static Vector2 GameResolution()
    {
      return new Vector2(1920f, 1080f);
    }
  }
}