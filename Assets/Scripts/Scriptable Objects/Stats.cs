using UnityEngine;

[CreateAssetMenu]
public class Stats : ScriptableObject
{
	public int MaxHP;
	public int HP;
	public int ATK;
	public int DEF;
	public float speed;

	public void Heal(int amount)
	{
		if (HP < MaxHP)
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