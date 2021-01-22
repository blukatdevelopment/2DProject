/*
  Just a god object. Nothing to see here, people.
*/
namespace Global {
  using Godot;
  using Actor;
  using Enums;
  using Constants;
  using Dialogue;
  using System.Collections.Generic;

  public class Session : Node2D
  {
    // Is that a naive singleton? You can bet your britches it is!
    public static Session session;
    public GameState state;
    public Dictionary<GameTypeEnum, Game> games;
    public GameTypeEnum activeGame;
    public DialogueManager dialogue;

    public override void _Ready()
    {
      EnforceSingleton();

      games = new Dictionary<GameTypeEnum, Game>();
      state = new GameState();
      AddChild(state);

      dialogue = new DialogueManager();
      AddChild(dialogue);
      
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

    public void Dialogue(DialogueTree tree)
    {
      dialogue.Activate(tree);
    }

    public void SelectOption(int option)
    {
      dialogue.SelectOption(option);
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
      activeGame = gameType;
    }

    public void Pause()
    {
      if(games.ContainsKey(activeGame))
      {
        games[activeGame].Pause();
      }
    }

    public void Resume()
    {
      if(games.ContainsKey(activeGame))
      {
        games[activeGame].Resume();
      }
    }
  }
}
