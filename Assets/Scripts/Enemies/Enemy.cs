using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	protected Animator anim;

	public Stats stats;

	public bool playerCollided;

	virtual protected void Awake() {
		anim = GetComponent<Animator>();
	}

	virtual protected void Start()
	{
		stats = ScriptableObject.Instantiate(stats);
	}

	virtual protected void Update()
	{
		Die();
	}

	abstract protected void Die();

	protected void Kill()
	{
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			playerCollided = true;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			playerCollided = false;
	}
}