namespace Input
{
  using Enums;

  // Contains information about an action
  public class ActionEvent
  {
    public ActionEnum action;
    
    public ActionEvent(ActionEnum action)
    {
      this.action = action;
    }
  }
}