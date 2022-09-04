using UnityEngine;

public abstract class Player : MonoBehaviour
{
	// Satistika
	public Stats stats;

	abstract protected void Awake();

	virtual protected void Update()
	{
		PlayerHealth.bar.ResizeHealthBar(stats.HP, stats.MAXHP);
	}

	// Pokrece igraca
	abstract protected void Move();

	// Umire
	abstract protected void Die();

	// Ubija igraca
	public void Kill()
	{
		Destroy(gameObject);
	}
}
