using System.Linq;
using UnityEngine;

public class Boss : Enemy
{
	private SpriteRenderer sr;

	[SerializeField]
	private LayerMask ground;

	[SerializeField]
    private RectTransform redBar;
	private float width;

	protected override void Awake()
	{
		base.Awake();
		sr = GetComponent<SpriteRenderer>();
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

	private void ResizeHealthBar()
	{
		float delta = stats.HP > 0.0f ? 1.0f * stats.HP / stats.MAXHP : 0.0f;
		redBar.sizeDelta = new Vector2(width * delta, redBar.sizeDelta.y);
	}

	private void ChangeColor()
	{
		if (stats.HP < stats.MAXHP / 2.0f)
		{
			sr.color = Color.HSVToRGB(0.0f, 0.3f, 1.0f);
			GetComponent<Rigidbody2D>().gravityScale = 0.0f;
			anim.SetBool("phase2", true);
		}
	}

	override protected void Die()
	{
		if (stats.IsDead())
		{
			foreach (GameObject sword in GameObject.FindGameObjectsWithTag("Sword"))
				Destroy(sword);

			anim.SetTrigger("fall");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
			playerCollided = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
			playerCollided = false;
    }
}
