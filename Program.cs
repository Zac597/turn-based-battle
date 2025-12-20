using System;
using System.Threading;
using TurnBasedBattle;
using TurnBasedBattle.Models;
using TurnBasedBattle.Core;
using TurnBasedBattle.Systems;
using TurnBasedBattle.Data;


class Program
{
  static void RenderLogs(BattleLog log)
  {
    foreach (var e in log.GetEvents())
    {
      Console.WriteLine(e.Message);
    }
  }

  static void Main()
  {
    Player player = new Player(12, 5);
    Enemy enemy = EnemyFactory.Create(EnemyDatabase.Slime);
    Battle battle = new Battle(player, enemy);
    var weakAttack = new Attack("Ataque fraco", 1, 1);
    var strongAttack = new Attack("Ataque forte", 3, 2);

    Console.WriteLine("=== Turn-Based Battle ===");

    while (true)
    {
      Console.WriteLine();
      Console.WriteLine($"Player HP: {player.Hp}, Stamina: {player.Stamina}/{player.MaxStamina}");
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
          {
              battle.PlayerAttack(weakAttack);
          }
          else if (input == "2")
          {
              battle.PlayerAttack(strongAttack);
          }
          else if (input == "3")
          {
              battle.PlayerDefend();
          }
          else
          {
              Console.WriteLine("Opção inválida.");
          }
          RenderLogs(battle.Log);
          battle.Log.Clear();
          break;

        case GamePhase.EnemyTurn:
          Console.WriteLine("turno do inimigo...");
          Thread.Sleep(500);

          battle.EnemyTurn();
          RenderLogs(battle.Log);
          battle.Log.Clear();
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