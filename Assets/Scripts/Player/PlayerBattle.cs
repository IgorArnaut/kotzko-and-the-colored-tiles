using UnityEngine;

public class PlayerBattle : Player
{
	// Components
	private CapsuleCollider2D cc;

	// Jump
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private LayerMask ground;

	public BoolValue defend;

	// Collision
	public bool enemyCollided;
	public GameObject enemy;

	override protected void Awake()
	{
		base.Awake();
		cc = GetComponent<CapsuleCollider2D>();
	}

	void Update()
	{
		Defend();

		if (!defend.value)
		{
			Attack();
			Heal();
			Die();
			Jump();
		}
	}

	void FixedUpdate()
	{
		if (!defend.value)
		{
			Move();
		}
	}

	override protected void Move()
	{
		float inputX = Input.GetAxisRaw("Horizontal");

		if (inputX <= 0.0f)
			sr.flipX = true;
		else
			sr.flipX = false;

		if (inputX > 0.0f || inputX <= 0.0f)
			anim.SetFloat("lastMoveX", inputX);

		if (rb.bodyType != RigidbodyType2D.Static)
			rb.velocity = new Vector2(inputX * stats.speed, rb.velocity.y);
	
		anim.SetFloat("horizontal", rb.velocity.x);
		anim.SetFloat("speed", rb.velocity.sqrMagnitude);
	}

	private void Jump()
	{
		bool grounded = IsGrounded();

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
			rb.velocity = Vector2.up * jumpForce;
	}

	private bool IsGrounded() {
		RaycastHit2D rc = Physics2D.CapsuleCast(cc.bounds.center, cc.bounds.size, CapsuleDirection2D.Horizontal, 0.0f, Vector2.down , 0.1f, ground);
		Debug.Log(rc.collider);
		return rc.collider != null;
	}

	private void Attack()
	{
		if (Input.GetMouseButtonDown(0))
			anim.SetTrigger("attack");
	}

	private void Defend()
	{
		if (Input.GetMouseButton(1))
		{
			defend.value = true;
			anim.SetBool("defend", true);
		} 
		else
		{
			defend.value = false;
			anim.SetBool("defend", false);
		}
	}

	private void Heal()
	{
		if (Input.GetKeyDown(KeyCode.Z))
			anim.SetTrigger("heal");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			enemyCollided = true;
			enemy = collision.gameObject;
		}
	}
	
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			enemyCollided = false;
			enemy = null;
		}
	}
}
