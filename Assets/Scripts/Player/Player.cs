using UnityEngine;

public abstract class Player : MonoBehaviour
{
	// Components
	protected Animator anim;
	protected Rigidbody2D rb;
	protected SpriteRenderer sr;

	// Stats
	public Stats stats;

	// Use this for initialization
	virtual protected void Awake()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	protected abstract void Move();

	protected void Die()
	{
		if (stats.IsDead())
		{
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			anim.SetTrigger("dead");
		}
	}

	public void Kill()
	{
		Destroy(gameObject);
	}
}
