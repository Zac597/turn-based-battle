namespace TurnBasedBattle.Core
{
  public enum GameEventType
  {
    Info,
    Attack,
    Defend,
    Damage,
    System
  }

  public class GameEvent
  {
    public GameEventType Type { get; }
    public string Message { get; }

    public GameEvent(GameEventType type, string message)
    {
      Type = type;
      Message = message;
    }
  }
}