using UnityEngine;

public class Boss : Enemy
{
	// Components
	private Animator anim;
	private Rigidbody2D rb2D;
	private SpriteRenderer sr;

	// Ground
	[SerializeField]
	private LayerMask ground;

	// Health bar
	[SerializeField]
    private RectTransform redBar;
	private float width;

	override protected void Awake()
	{
		GetComponents();
	}

	override protected void Start()
	{
        base.Start();
		width = redBar.sizeDelta.x;
	}

	override protected void Update()
	{
        base.Update();
		ResizeHealthBar();
		ChangeColor();
	}

	// Get Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();

	}

	// Health bar
	private void ResizeHealthBar()
	{
		float delta = stats.HP > 0.0f ? 1.0f * stats.HP / stats.MAXHP : 0.0f;
		redBar.sizeDelta = Vector2.Lerp(redBar.sizeDelta, new Vector2(width * delta, redBar.sizeDelta.y), Time.deltaTime / 0.01f);
	}

	// ChangeColor
	private void ChangeColor()
	{
		if (stats.HP < stats.MAXHP / 2.0f)
		{
			rb2D.gravityScale = 0.0f;
			sr.color = Color.HSVToRGB(0.0f, 0.3f, 1.0f);
			anim.SetBool("phase2", true);
		}
	}

	// Death
	override protected void Die()
	{
		if (stats.IsDead())
		{
			foreach (GameObject sword in GameObject.FindGameObjectsWithTag("Sword")) Destroy(sword);
			anim.SetTrigger("fall");
		}
	}


	// Collision
	private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) playerCollided = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) playerCollided = false;
    }
}
