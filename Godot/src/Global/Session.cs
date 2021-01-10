/*
  Just a god object. Nothing to see here, people.
*/
namespace Global {
  using Godot;
  using Actor;
  using Enums;
  using Constants;
  using System.Collections.Generic;

  public class Session : Node2D
  {
    // Is that a naive singleton? You can bet your britches it is!
    public static Session session;
    public GameState state;
    public Dictionary<GameTypeEnum, Game> games;

    public override void _Ready()
    {
      EnforceSingleton();
      games = new Dictionary<GameTypeEnum, Game>();
      state = new GameState();
      AddChild(state);
      GD.Print("Session initialized");
      StartNewGame(GameTypeEnum.Shooter);
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

    public void StartNewGame(GameTypeEnum gameType)
    {
      if(games.ContainsKey(gameType))
      {
        games[gameType].End();
        games[gameType].QueueFree();
        games.Remove(gameType);
      }

      games[gameType] = GameConstants.NewGameByType(gameType, state);
      AddChild(games[gameType]);
      games[gameType].Start();
    }
  }
}
