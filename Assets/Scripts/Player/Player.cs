using UnityEngine;

public abstract class Player : MonoBehaviour
{
	// Stats
	public Stats stats;

	abstract protected void Awake();

	virtual protected void Update()
	{
		PlayerHealth.bar.ResizeHealthBar(stats.HP, stats.MAXHP);
	}

	// Moves Player
	abstract protected void Move();

	// Dies
	abstract protected void Die();

	// Kills Player
	public void Kill()
	{
		Destroy(gameObject);
	}
}
