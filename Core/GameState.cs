  using TurnBasedBattle.Models;

  namespace TurnBasedBattle.Core
  {
    public class GameState
    {
      public Player Player { get; }
      public Enemy Enemy { get; }
      public GamePhase Phase { get; }

      public GameState(Player player, Enemy enemy, GamePhase phase)
      {
        Player = player;
        Enemy = enemy;
        Phase = phase;
      }
    }
  }