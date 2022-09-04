using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	// Statistika
	public Stats stats;

	// Igrac
	public bool playerCollided;

	abstract protected void Awake();

	void Start()
	{
		stats = ScriptableObject.Instantiate(stats);
	}

	virtual protected void Update()
	{
		Die();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) playerCollided = true;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) playerCollided = false;
	}

	// Umire
	abstract protected void Die();

	// Ubija neprijatelja
	protected void Kill()
	{
		Destroy(gameObject);
	}
}