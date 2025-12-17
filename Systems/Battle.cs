using TurnBasedBattle.Models;

namespace TurnBasedBattle
{
  public class Battle
  {
    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }
    public bool IsPlayerTurn { get; private set; }

    public Battle(Player player, Enemy enemy)
    {
      Player = player;
      Enemy = enemy;
      IsPlayerTurn = true;
    }

    public void PlayerAttack(int damage, int staminaCost)
    {
      if(!IsPlayerTurn) return;
      if(Player.Stamina < staminaCost) return;

      Enemy.Hp -= damage;
      Player.Stamina -= staminaCost;
      Player.IsDefending = false;

      IsPlayerTurn = false;
    }

    public void PlayerDefend()
    {
      if (!IsPlayerTurn) return;

      Player.Stamina += 1;
      Player.IsDefending = true;

      IsPlayerTurn = false;
    }

    public void EnemyTurn()
    {
      if (IsPlayerTurn) return;
      
      int damage = Player.IsDefending ? 1 : 2;

      Player.Hp -= damage;
      Player.IsDefending = false;

      IsPlayerTurn = true;
    }

    public bool IsGameOver()
    {
      return Player.Hp <= 0 || Enemy.Hp <= 0;
    }
  }
}