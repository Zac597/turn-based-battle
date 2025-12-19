  using TurnBasedBattle.Models;

  namespace TurnBasedBattle.Core
  {
    public class GameState
    {
      public Player Player { get; }
      public Enemy Enemy { get; }
      public bool IsPlayerTurn { get; }
      public bool  IsGameOver { get; }

      public GameState(Player player, Enemy enemy, bool isPlayerTurn, bool isGameOver)
      {
        Player = player;
        Enemy = enemy;
        IsPlayerTurn = isPlayerTurn;
        IsGameOver = isGameOver;
      }
    }
  }