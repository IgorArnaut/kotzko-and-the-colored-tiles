using UnityEngine;

public class Boss : Enemy
{
	private CapsuleCollider2D cc;
	private SpriteRenderer sr;

	[SerializeField]
	private LayerMask ground;

	[SerializeField]
    private RectTransform redBar;

	private float width;

	protected override void Awake()
	{
		base.Awake();
		cc = GetComponent<CapsuleCollider2D>();
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

		float delta = stats.HP > 0.0f ? 1.0f * stats.HP / stats.MaxHP : 0.0f;
		redBar.sizeDelta = Vector2.Lerp(redBar.sizeDelta, new Vector2(width * delta, redBar.sizeDelta.y), 100.0f * Time.deltaTime);

		if (stats.HP < stats.MaxHP / 2.0f) {
			sr.color = Color.HSVToRGB(0.0f, 0.3f, 1.0f);
			anim.SetBool("phase2", true);
		}
	}

	private bool IsGrounded()
	{
		RaycastHit2D rc = Physics2D.CapsuleCast(cc.bounds.center, cc.bounds.size, CapsuleDirection2D.Horizontal, 0.0f, Vector2.down, 0.1f, ground);
		Debug.Log(rc.collider);
		return rc.collider != null;
	}

	override protected void Die()
	{
		if (stats.IsDead())
		{
			if (!IsGrounded())
				anim.SetTrigger("fall");
			else
				anim.SetTrigger("dead");
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
