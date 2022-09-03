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

	override protected void Awake()
	{
		GetComponents();
	}

	override protected void Update()
	{
        base.Update();
		BossHealth.bar.ResizeHealthBar(stats.HP, stats.MAXHP);
		ChangeColor();
	}

	// Gets Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();

	}

	// Changes color of boss
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
