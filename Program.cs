using TurnBasedBattle;
using TurnBasedBattle.Models;

class Program
{
  static void Main()
  {
    Player player = new Player(10, 5);
    Enemy enemy = new Enemy(12);
    Battle battle = new Battle(player, enemy);

    Console.WriteLine("=== Turn-Based Battle ===");

    while (!battle.IsGameOver())
    {
      Console.WriteLine();
      Console.WriteLine($"Player HP: {player.Hp}, Stamina: {player.Stamina}");
      Console.WriteLine($"Enemy HP: {enemy.Hp}");

      if (battle.IsPlayerTurn)
      {
        Console.WriteLine("Seu Turno");
        Console.WriteLine("1 - Ataque fraco (1 dano, 1 stamina)");
        Console.WriteLine("2 - Ataque forte (3 dano, 2 stamina)");
        Console.WriteLine("3 - Defender (+1 stamina)");

        string? input = Console.ReadLine();

        switch (input)
        {
          case "1":
            battle.PlayerAttack(1, 1);
            break;
          case "2":
            battle.PlayerAttack(3, 2);
            break;
          case "3":
            battle.PlayerDefend();
            break;
          default: 
            Console.WriteLine("Ação inválida");
            break;
        }
      }
    else
    {
      Console.WriteLine("Turno do inimigo...");
      Thread.Sleep(500);
      battle.EnemyTurn();
    }
    }
    Console.WriteLine();
    Console.WriteLine(player.Hp > 0 ? "Você venceu!" : "Você perdeu!");
  }
}