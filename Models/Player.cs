namespace TurnBasedBattle.Models
{
  public class Player
  {
    public int Hp { get; set; }
    public int Stamina { get; set; }
    public int MaxStamina { get; }
    public bool IsDefending { get; set; }

    public Player(int hp, int stamina)
    {
      Hp = hp;
      MaxStamina = stamina;
      Stamina = stamina;
      IsDefending = false;
    }
  }
}