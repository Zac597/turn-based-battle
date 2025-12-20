using TurnBasedBattle.Models;
using TurnBasedBattle.Systems;
using TurnBasedBattle.Core;
using System;
using System.Threading;

namespace TurnBasedBattle
{
  public static class CombatRules
  {
      public const int EnemyWeakDamage = 1;
      public const int EnemyStrongDamage = 2;
      public const int EnemyMissChance = 15;
      public const int EnemyStrongChance = 40;
  }

  public class Battle
  {
    private static readonly Random _rng = new Random();

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

    public void PlayerAttack(Attack attack)
    {

        if (Phase != GamePhase.PlayerTurn)
        {
            Log.Add(GameEventType.System, "Não é o seu turno.");
            return;
        }

        if (Player.Stamina < attack.StaminaCost)
        {
            Log.Add(GameEventType.System, "Stamina insuficiente.");
            return;
        }

        Enemy.Hp -= attack.Damage;
        Player.Stamina -= attack.StaminaCost;
        Player.IsDefending = false;

        Log.Add(GameEventType.Attack, $"Player usou {attack.Name} e causou {attack.Damage} de dano.");

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
      if (Player.Stamina >= Player.MaxStamina)
        {
          Log.Add(GameEventType.System, "Sua stamina já está cheia, você precisa atacar.");
        }
      else
        {
          Player.Stamina += 1;
          Log.Add(GameEventType.Defend, "Player se defendeu e recuperou 1 de stamina.");
        }

      Player.IsDefending = true;
      Phase = GamePhase.EnemyTurn;
    }

    public void EnemyTurn()
    {
      if (Phase != GamePhase.EnemyTurn) return;
      Thread.Sleep(600);
      
      Log.Add(GameEventType.System, $"{Enemy.Profile.Name} está se preparando...");

      int roll = _rng.Next(1, 101);

      if(roll <= Enemy.Profile.MissChance)
      {
        Log.Add(GameEventType.System, "O inimigo errou o ataque!");
      }
      else
      {
        int baseDamage;

        if (roll <= Enemy.Profile.MissChance + Enemy.Profile.StrongChance)
        {
          baseDamage = Enemy.Profile.StrongDamage;
          Log.Add(GameEventType.System, $"{Enemy.Profile.Name} usou um ATAQUE FORTE!");
        }
        else
        {
          baseDamage = Enemy.Profile.WeakDamage;
          Log.Add(GameEventType.System, $"{Enemy.Profile.Name} atacou!");
        }

        int finalDamage = Player.IsDefending ? baseDamage - 1 : baseDamage;
        finalDamage = Math.Max(0, finalDamage);

        Player.Hp -= finalDamage;
        Log.Add(GameEventType.Attack, $"E causou {finalDamage} de dano.");
      }

      Player.IsDefending = false;

      
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