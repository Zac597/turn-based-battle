using System.Collections.Generic;
using TurnBasedBattle.Core;

namespace TurnBasedBattle.Systems
{
  public class BattleLog
  {
    private List<GameEvent> _events = new();

    public void Add(GameEventType type, string message)
    {
      _events.Add(new GameEvent(type, message));
    }

    public IReadOnlyList<GameEvent> GetEvents()
    {
      return _events;
    }

    public void Clear()
    {
      _events.Clear();
    }
  }
}