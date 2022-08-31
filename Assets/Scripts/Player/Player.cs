using UnityEngine;

public abstract class Player : MonoBehaviour
{
	protected Animator anim;
	protected Rigidbody2D rb;
	protected SpriteRenderer sr;

	public Stats stats;

	virtual protected void Awake()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	protected abstract void Move();

	protected abstract void Die();

	public void Kill()
	{
		Destroy(gameObject);
	}
}
