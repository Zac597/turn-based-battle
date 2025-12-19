using TurnBasedBattle.Models;
using TurnBasedBattle.Systems;
using TurnBasedBattle.Core;

namespace TurnBasedBattle
{
  public class Battle
  {
    public Player Player { get; }
    public Enemy Enemy { get; }
    public bool IsPlayerTurn { get; private set; }

    public BattleLog Log { get; }

    public Battle(Player player, Enemy enemy)
    {
      Player = player;
      Enemy = enemy;
      IsPlayerTurn = true;
      Log = new BattleLog();
    }

    public void PlayerAttack(int damage, int staminaCost, string attackName)
    {
      if(!IsPlayerTurn) return;
      if(Player.Stamina < staminaCost) return;

      Enemy.Hp -= damage;
      Player.Stamina -= staminaCost;
      Player.IsDefending = false;

      Log.Add(GameEventType.Attack, $"Player usou {attackName} e causou {damage} de dano;");

      IsPlayerTurn = false;
    }

    public void PlayerDefend()
    {
      if (!IsPlayerTurn)
      {
        Log.Add(GameEventType.Attack, "Não é o seu turno.");
        return;
      }

      Player.Stamina += 1;
      Player.IsDefending = true;

      Log.Add(GameEventType.Attack, "Player está se defendendo e recuperou 1 de stamina.");

      IsPlayerTurn = false;
    }

    public void EnemyTurn()
    {
      if (IsPlayerTurn) return;
      
      int damage = Player.IsDefending ? 1 : 2;

      Player.Hp -= damage;
      Player.IsDefending = false;

      Log.Add(GameEventType.Attack, $"Inimigo atacou e causou {damage} de dano.");

      IsPlayerTurn = true;
    }

    public bool IsGameOver()
    {
      return Player.Hp <= 0 || Enemy.Hp <= 0;
    }
  }
}