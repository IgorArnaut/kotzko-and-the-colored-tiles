using UnityEngine;

[CreateAssetMenu]
public class Stats : ScriptableObject
{
	// Vrednosti
	public int MAXHP;
	public int HP;
	public int ATK;
	public int DEF;
	public float SPEED;

	// Povecava HP
	public void Heal(int amount)
	{
		if (this.HP + amount < this.MAXHP) this.HP += amount;
	}

	// Smanjuje HP
	public void TakeDamge(int amount)
	{
		if (this.HP > 0) this.HP -= (int) (amount * (100.0f / (100 + this.DEF)));
	}

	// Proverava da li je HP 0
	public bool IsDead()
	{
		return this.HP <= 0;
	}

	// Resetuje vrednosti
	public void ResetStats(int MAXHP, int HP, int ATK, int DEF, float SPEED)
	{
		this.MAXHP = MAXHP;
		this.HP = HP;
		this.ATK = ATK;
		this.DEF = DEF;
		this.SPEED = SPEED;
	}
}