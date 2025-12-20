namespace TurnBasedBattle.Models
{
  public class Attack
  {
    public string Name { get; }
    public int Damage { get; }
    public int StaminaCost { get; }

    public Attack(string name, int damage, int staminaCost)
    {
      Name = name;
      Damage = damage;
      StaminaCost = staminaCost;
    }
  }
}