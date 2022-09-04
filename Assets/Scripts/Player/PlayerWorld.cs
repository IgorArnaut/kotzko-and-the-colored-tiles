using UnityEngine;

public class PlayerWorld : Player
{
	// Komponente
	private Animator anim;
	private Rigidbody2D rb2D;
	private SpriteRenderer sr;

	// Status efekti
	public BoolValue inWater;
	public BoolValue electric;
	public BoolValue heal;
	public BoolValue orange;
	public BoolValue purple;

	override protected void Awake()
	{
		GetComponents();
	}

	override protected void Update()
	{
		base.Update();
		ChangeStatus();
		Die();
	}

	void FixedUpdate()
	{
		Move();
		Swim();
	}

	// Uzima komponente
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	// Pokrece igraca
	override protected void Move()
	{
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		if (inputX == 1.0f) {
			sr.flipX = true;
			transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
		}

		if (inputX == -1.0f) {
			sr.flipX = false;
			transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
		}

		if (inputX == -1.0f || inputX == 1.0f || inputY == -1.0f || inputY == 1.0f)
		{
			anim.SetFloat("lastMoveX", inputX);
			anim.SetFloat("lastMoveY", inputY);
		}

		if (rb2D.bodyType != RigidbodyType2D.Static) rb2D.velocity = new Vector2(inputX, inputY) * stats.SPEED;

		anim.SetFloat("horizontal", rb2D.velocity.x);
		anim.SetFloat("vertical", rb2D.velocity.y);
		anim.SetFloat("speed", rb2D.velocity.sqrMagnitude);
	}

	// Pliva
	private void Swim()
	{
		anim.SetBool("inWater", inWater.value);
		transform.GetChild(1).gameObject.SetActive(inWater.value);
	}

	// Umire
	protected override void Die()
	{
		if (orange.value && inWater.value) anim.SetTrigger("deadw");

		if (stats.IsDead()) if (!inWater.value) anim.SetTrigger("dead"); else anim.SetTrigger("deadw");
	}

	// Menja status efekat
	private void ChangeStatus()
	{
		anim.SetBool("electric", electric.value);

		if (orange.value)
		{
			sr.color = Color.Lerp(Color.HSVToRGB(30.0f / 360.0f, 0.3f, 1.0f), Color.white, Mathf.PingPong(Time.time, 2.0f));

			if (inWater.value)
			{
				sr.color = Color.white;
				anim.SetTrigger("deadw");
			}
		}
		else if (purple.value) sr.color = Color.Lerp(Color.HSVToRGB(270.0f / 360.0f, 0.3f, 1.0f), Color.white, Mathf.PingPong(Time.time, 2.0f));
		else if (heal.value) sr.color = Color.Lerp(Color.HSVToRGB(300.0f / 360.0f, 0.3f, 1.0f), Color.white, Mathf.PingPong(Time.time, 2.0f));
		else sr.color = Color.white;
	}
}
