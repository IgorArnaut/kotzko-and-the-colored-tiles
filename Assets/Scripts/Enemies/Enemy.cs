using UnityEngine;

public class Enemy : MonoBehaviour
{
	protected Animator anim;

	public Stats stats;

	public bool playerCollided;

	void Awake() {
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

	private void Die()
	{
		if (stats.IsDead())
		{
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			anim.SetTrigger("dead");
		}
	}

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