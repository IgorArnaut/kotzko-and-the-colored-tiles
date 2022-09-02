using UnityEngine;

public abstract class Player : MonoBehaviour
{
	// Stats
	public Stats stats;

	abstract protected void Awake();

	// Move
	abstract protected void Move();

	// Die
	abstract protected void Die();

	// Kill
	public void Kill()
	{
		Destroy(gameObject);
	}
}
