namespace TurnBasedBattle.Models
{
  public class Enemy
  {
    public EnemyProfile Profile { get; }
    public int Hp { get; set; }

    public Enemy(EnemyProfile profile)
    {
      Profile = profile;
      Hp = profile.MaxHp;
    }
  }
}