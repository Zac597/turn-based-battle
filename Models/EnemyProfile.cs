namespace TurnBasedBattle.Models
{
  public class EnemyProfile
  {
    public string Name { get; }
    public int MaxHp { get; }

    public int WeakDamage { get; }
    public int StrongDamage { get; }

    public int MissChance { get; }
    public int StrongChance { get; }

    public EnemyProfile(
      string name,
      int maxHp,
      int weakDamage,
      int strongDamage,
      int misschance,
      int strongChance
    )
    {
      Name = name;
      MaxHp = maxHp;
      WeakDamage = weakDamage;
      StrongDamage = strongDamage;
      MissChance = misschance;
      StrongChance = strongChance;
    }
  }
}