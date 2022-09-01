using UnityEngine;

[CreateAssetMenu]
public class Stats : ScriptableObject
{
	public int MAXHP;
	public int HP;
	public int ATK;
	public int DEF;
	public float SPEED;

	public void Heal(int amount)
	{
		if (HP < MAXHP)
			HP += amount;
	}

	public void TakeDamge(int amount)
	{
		if (HP > 0)
			HP -= (int) (amount * (100.0f / (100 + DEF)));
	}

	public bool IsDead()
	{
		return HP <= 0;
	}
}