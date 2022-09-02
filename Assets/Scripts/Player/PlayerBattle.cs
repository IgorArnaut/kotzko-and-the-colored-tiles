using UnityEngine;

public class PlayerBattle : Player
{
	// Components
	private Animator anim;
	private CapsuleCollider2D cc2D;
	private Rigidbody2D rb2D;
	private SpriteRenderer sr;

	// Jump
	[SerializeField]
	private LayerMask ground;
	private bool grounded;
	[SerializeField]
	private float jumpForce;

	// Defend
	public BoolValue defend;

	// Enemy
	public GameObject enemy;
	public bool enemyCollided;

	override protected void Awake()
	{
		GetComponents();
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

	// Get Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		cc2D = GetComponent<CapsuleCollider2D>();
		rb2D = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	override protected void Move()
	{
		float inputX = Input.GetAxisRaw("Horizontal");
		if (inputX == -1.0f || inputX == 1.0f) anim.SetFloat("lastMoveX", inputX);
		if (inputX == 1.0f) sr.flipX = false;
		if (inputX == -1.0f) sr.flipX = true;
		if (rb2D.bodyType != RigidbodyType2D.Static) rb2D.velocity = new Vector2(inputX * stats.SPEED, rb2D.velocity.y);
		anim.SetFloat("horizontal", rb2D.velocity.x);
		anim.SetFloat("speed", rb2D.velocity.sqrMagnitude);
	}

	protected override void Die()
	{
		if (stats.IsDead()) anim.SetTrigger("dead");
	}

	private void Jump()
	{
		grounded = IsGrounded();

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			anim.SetTrigger("jump");
			rb2D.velocity = Vector2.up * jumpForce;
		}
	}

	private bool IsGrounded() {
		RaycastHit2D rc = Physics2D.CapsuleCast(cc2D.bounds.center, cc2D.bounds.size, CapsuleDirection2D.Horizontal, 0.0f, Vector2.down , 0.1f, ground);
		return rc.collider != null;
	}

	private void Attack()
	{
		if (Input.GetMouseButtonDown(0)) anim.SetTrigger("attack");
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
		if (Input.GetKeyDown(KeyCode.Q)) anim.SetTrigger("heal");
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
