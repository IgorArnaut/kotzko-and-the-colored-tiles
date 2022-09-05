using UnityEngine;

public class Boss : Enemy
{
	// Komponente
	private Animator anim;
	private Rigidbody2D rb2D;
	private SpriteRenderer sr;

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

	// Uzima komponente
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();

	}

	// Menja boju Boss kad mu he HP upola mnaji
	private void ChangeColor()
	{
		if (stats.HP < stats.MAXHP / 2.0f)
		{
			anim.SetBool("phase2", true);
			rb2D.gravityScale = 0.0f;
			sr.color = Color.HSVToRGB(0.0f, 0.3f, 1.0f);
		}
	}

	// Unistava sve maceve tokom povrede
	public void DestroySwords()
	{
		foreach (GameObject sword in GameObject.FindGameObjectsWithTag("Sword")) Destroy(sword);
	}

	// Umire
	override protected void Die()
	{
		if (stats.IsDead())
		{
			foreach (GameObject sword in GameObject.FindGameObjectsWithTag("Sword")) Destroy(sword);
			anim.SetTrigger("fall");
		}
	}
}
