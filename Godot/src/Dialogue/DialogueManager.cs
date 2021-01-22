namespace Dialogue
{
  using System.Collections.Generic;
  using Godot;
  using Global;
  using Constants;

  public class DialogueManager : Node2D
  {
    public DialogueTree activeTree;
    public Label messageLabel;    
    public ColorRect messagePanel;
    private bool hideTextTimerActive = false;
    private float hideTextTimer = 0f;
    private float displayTime = 0f;
    private List<Button> optionButtons;

    public DialogueManager()
    {
      displayTime = DialogueConstants.DefaultDialogueDisplayTime;

      Vector2 oneTenthRes = GameConstants.GameResolution()/10f;

      messagePanel = new ColorRect();
      messagePanel.RectMinSize = oneTenthRes;
      messagePanel.Color = new Color(0, 0, 0, 255);
      AddChild(messagePanel);

      messageLabel = new Label();
      messageLabel.Text = "Cool text";
      messageLabel.RectMinSize = oneTenthRes;
      messageLabel.AddColorOverride("font_color", new Color(255, 255, 255, 255));
      AddChild(messageLabel);

      optionButtons = new List<Button>();
      for(int i = 0; i < 4; i++)
      {
        Button button = new Button();
        button.Text = "Example";
        button.RectMinSize = oneTenthRes;
        button.AddColorOverride("font_color", new Color(255, 255, 255, 255));
        button.RectGlobalPosition = new Vector2(
          messageLabel.RectGlobalPosition.x, 
          messageLabel.RectGlobalPosition.y + oneTenthRes.y * (i+1));
        
        button.Connect("pressed", this, "Button"+i);
        AddChild(button);
        optionButtons.Add(button);
      }

      ShowDialogue(false);
    }

    public void Activate(DialogueTree tree, int activeNode = -1)
    {
      activeTree = tree;
      DisplayNode(activeTree.GetActiveNode());
    }

    public void DisplayNode(DialogueNode node)
    {
      if(node == null)
      {
        ShowDialogue(false);
        return;
      }
      messageLabel.Text = node.message.displayText;
      ShowDialogue(true);
      if(node.HasNoOptions())
      {
        hideTextTimerActive = true;
        hideTextTimer = 0f;
      }
      else
      {
        Session.session.Pause();
        foreach(DialogueOption option in node.options)
        {
          DisplayOption(option);
        }
      }
    }

    public void DisplayOption(DialogueOption option)
    {
      Button button = optionButtons[option.optionId];
      button.Text = option.displayText;
      button.Visible = true;
    }

    public void ShowDialogue(bool show)
    {
      messageLabel.Visible = show;
      messagePanel.Visible = show;

      if(!show)
      {
        foreach(Button button in optionButtons)
        {
          button.Visible = show;
        }

        Session.session.Resume();
      }
    }

    public override void _Process(float delay)
    {
      if(hideTextTimerActive == true)
      {
        hideTextTimer += delay;
        if(hideTextTimer >= displayTime)
        {
          hideTextTimerActive = false;
          ShowDialogue(false);
        }
      }
    }

    public void SelectOption(int optionId)
    {
      DialogueNode node = activeTree.GetActiveNode();
      DialogueOption option = node.GetOption(optionId);
      if(option != null)
      {
        GD.Print("Displaying node " + option.destinationNode);
        activeTree.activeNode = option.destinationNode;
        Activate(activeTree, option.destinationNode);
      }
      else
      {
        ShowDialogue(false);
      }
    }

    public void Button0()
    {
      SelectOption(0);
    }

    public void Button1()
    {
      SelectOption(1);
    }

    public void Button2()
    {
      SelectOption(2);
    }

    public void Button3()
    {
      SelectOption(3);
    }
  }
}