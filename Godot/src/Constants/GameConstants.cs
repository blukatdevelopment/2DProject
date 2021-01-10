namespace Constants
{
  using Global;
  using Enums;
  using Godot;
  using Shooter;

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
        break;
        default:
          GD.Print("NewGameByType: invalid gameType: " + gameType);
          return null;
        break;
      }
    }
  }
}