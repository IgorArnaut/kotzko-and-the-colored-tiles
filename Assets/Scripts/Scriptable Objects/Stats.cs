using UnityEngine;

[CreateAssetMenu]
public class Stats : ScriptableObject
{
	// Stats
	public int MAXHP;
	public int HP;
	public int ATK;
	public int DEF;
	public float SPEED;

	// Increases HP
	public void Heal(int amount)
	{
		if (this.HP < this.MAXHP) this.HP += amount;
	}

	// Decreases HP
	public void TakeDamge(int amount)
	{
		if (this.HP > 0) this.HP -= (int) (amount * (100.0f / (100 + this.DEF)));
	}

	// Checks if HP is 0
	public bool IsDead()
	{
		return this.HP <= 0;
	}

	// Resets all stats
	public void ResetStats(int MAXHP, int HP, int ATK, int DEF, float SPEED)
	{
		this.MAXHP = MAXHP;
		this.HP = HP;
		this.ATK = ATK;
		this.DEF = DEF;
		this.SPEED = SPEED;
	}
}