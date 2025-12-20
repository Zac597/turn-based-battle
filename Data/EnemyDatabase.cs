using TurnBasedBattle.Models;
using System.Collections.Generic;

namespace TurnBasedBattle.Data
{
  public static class EnemyDatabase
  {
    public static readonly EnemyProfile Slime = new EnemyProfile(
      name: "Slime",
      maxHp: 12,
      weakDamage: 1,
      strongDamage: 2,
      misschance: 20,
      strongChance: 35
    );

    public static readonly EnemyProfile Goblin = new EnemyProfile(
      name: "Globlin",
      maxHp: 15,
      weakDamage: 2,
      strongDamage: 3,
      misschance: 20,
      strongChance: 40
    );

    public static IReadOnlyList<EnemyProfile> All = new List<EnemyProfile>
    {
      Slime,
      Goblin
    };
  }
}