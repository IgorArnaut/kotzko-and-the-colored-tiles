using UnityEngine;

public class PlayerBattle : Player
{
	private CapsuleCollider2D cc;

	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private LayerMask ground;
	private bool grounded;

	public BoolValue defend;

	public bool enemyCollided;
	public GameObject enemy;

	override protected void Awake()
	{
		base.Awake();
		cc = GetComponent<CapsuleCollider2D>();
	}

	private void Start()
	{
		anim.SetFloat("lastMoveX", 1.0f);
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
			Move();
	}

	override protected void Move()
	{
		float inputX = Input.GetAxisRaw("Horizontal");

		if (inputX == -1.0f || inputX == 1.0f)
			anim.SetFloat("lastMoveX", inputX);

		if (inputX == 1.0f)
			sr.flipX = false;

		if (inputX == -1.0f)
			sr.flipX = true;

		if (rb.bodyType != RigidbodyType2D.Static)
			rb.velocity = new Vector2(inputX * stats.speed, rb.velocity.y);
	
		anim.SetFloat("horizontal", rb.velocity.x);

		anim.SetFloat("speed", rb.velocity.sqrMagnitude);
	}

	protected override void Die()
	{
		if (stats.IsDead())
			anim.SetTrigger("dead");
	}

	private void Jump()
	{
		grounded = IsGrounded();

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			anim.SetTrigger("jump");
			rb.velocity = Vector2.up * jumpForce;
		}
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
