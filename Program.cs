using System;
using System.Threading;
using TurnBasedBattle;
using TurnBasedBattle.Models;
using TurnBasedBattle.Core;


class Program
{
  static void Main()
  {
    Player player = new Player(10, 5);
    Enemy enemy = new Enemy(12);
    Battle battle = new Battle(player, enemy);

    Console.WriteLine("=== Turn-Based Battle ===");

    while (true)
    {
      Console.WriteLine();
      Console.WriteLine($"Player HP: {player.Hp}, Stamina: {player.Stamina}");
      Console.WriteLine($"Enemy HP: {enemy.Hp}");
      Console.WriteLine();

      var state = battle.GetState();

      switch (state.Phase)
      {
        case GamePhase.PlayerTurn:
          Console.WriteLine("Seu Turno");
          Console.WriteLine("1 - Ataque fraco");
          Console.WriteLine("2 - Ataque forte");
          Console.WriteLine("3 - Defender");
                                
          var input = Console.ReadLine();

          if (input == "1")
              battle.PlayerAttack(2, 1, "Ataque fraco");
          else if (input == "2")
              battle.PlayerAttack(3, 2, "Ataque forte");
          else if (input == "3")
              battle.PlayerDefend();
          break;

        case GamePhase.EnemyTurn:
          Console.WriteLine("turno do inimigo...");
          Thread.Sleep(500);
          battle.EnemyTurn();
          break;

        case GamePhase.Victory:
          Console.WriteLine("Você venceu!");
          return;
        case GamePhase.Defeat:
          Console.WriteLine("Você perdeu");
          return;
      }
    }
  }
}