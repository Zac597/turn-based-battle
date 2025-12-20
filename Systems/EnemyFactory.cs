using TurnBasedBattle.Models;

namespace TurnBasedBattle.Systems
{
  public static class EnemyFactory
  {
    public static Enemy Create(EnemyProfile profile)
    {
      return new Enemy(profile);
    }
  }
}