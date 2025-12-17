namespace TurnBasedBattle.Models
{
  public class Player
  {
    public int Hp { get; set; }
    public int Stamina { get; set; }
    public bool IsDefending { get; set; }

    public Player(int hp, int stamina)
    {
      Hp = hp;
      Stamina = stamina;
      IsDefending = false;
    }
  }
}