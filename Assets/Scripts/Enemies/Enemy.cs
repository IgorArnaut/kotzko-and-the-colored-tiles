using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	// Stats
	public Stats stats;

	// Player
	public bool playerCollided;

	abstract protected void Awake();

	virtual protected void Start()
	{
		stats = ScriptableObject.Instantiate(stats);
	}

	virtual protected void Update()
	{
		Die();
	}

	// Death
	abstract protected void Die();

	protected void Kill()
	{
		Destroy(gameObject);
	}

	// Collision
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) playerCollided = true;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) playerCollided = false;
	}
}