using TurnBasedBattle.Models;
using TurnBasedBattle.Systems;
using TurnBasedBattle.Core;

namespace TurnBasedBattle
{
  public class Battle
  {
    public Player Player { get; }
    public Enemy Enemy { get; }
    public GamePhase Phase { get; private set; }
    public BattleLog Log { get; }

    public Battle(Player player, Enemy enemy)
    {
      Player = player;
      Enemy = enemy;
      Phase = GamePhase.PlayerTurn;
      Log = new BattleLog();
    }

    public void PlayerAttack(int damage, int staminaCost, string attackName)
    {
      if(Phase != GamePhase.PlayerTurn)
      {
        Log.Add(GameEventType.System, "Não é o seu turno");
        return;
      }

      if(Player.Stamina < staminaCost)
      {
        Log.Add(GameEventType.System, "Stamina insuficiente.");
        return;
      }

      Enemy.Hp -= damage;
      Player.Stamina -= staminaCost;
      Player.IsDefending = false;

      Log.Add(GameEventType.Attack, $"Player usou {attackName} e causou {damage} de dano.");

      if (Enemy.Hp <= 0)
      {
          Phase = GamePhase.Victory;
          Log.Add(GameEventType.System, "Você venceu a batalha!");
          return;
      }


      Phase = GamePhase.EnemyTurn;
    }

    public void PlayerDefend()
    {
      if (Phase != GamePhase.PlayerTurn)
      {
        Log.Add(GameEventType.System, "Não é o seu turno.");
        return;
      }

      Player.Stamina += 1;
      Player.IsDefending = true;

      Log.Add(GameEventType.Attack, "Player está se defendendo e recuperou 1 de stamina.");

      Phase = GamePhase.EnemyTurn;
    }

    public void EnemyTurn()
    {
      if (Phase != GamePhase.EnemyTurn) return;
      
      int damage = Player.IsDefending ? 1 : 2;

      Player.Hp -= damage;
      Player.IsDefending = false;

      Log.Add(GameEventType.Attack, $"Inimigou atacou e causou {damage} de dano.");
      
      if (Player.Hp <= 0)
      {
        Phase = GamePhase.Defeat;
        Log.Add(GameEventType.System, "Você foi derrotado...");
        return;
      }
      Phase = GamePhase.PlayerTurn;
    }

    public bool IsGameOver()
    {
      return Player.Hp <= 0 || Enemy.Hp <= 0;
    }
  
    public GameState GetState()
    {
      return new GameState(Player, Enemy, Phase);
    }
  }
}