using UnityEngine;

public class Boss : Enemy
{
    [SerializeField]
    private RectTransform redBar;

	private float width;

	override protected void Start()
	{
        base.Start();
		width = redBar.sizeDelta.x;
	}

	override protected void Update()
	{
        base.Update();

		float delta = stats.HP > 0.0f ? 1.0f * stats.HP / stats.MaxHP : 0.0f;
		redBar.sizeDelta = new Vector2(width * delta, redBar.sizeDelta.y);

        anim.SetBool("phase2", stats.HP < stats.MaxHP / 2.0f);
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
