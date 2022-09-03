using UnityEngine;

public class BossHealth : MonoBehaviour, IHealthBar
{
	public static BossHealth bar;

	// Health bar
	[SerializeField]
	private RectTransform redBar;
	private float width;

	void Awake()
	{
		bar = this;
	}

	void Start()
	{
		width = redBar.sizeDelta.x;
	}

	// Resizes boss health bar
	public void ResizeHealthBar(int HP, int MAXHP)
	{
		float delta = HP > 0.0f ? 1.0f * HP / MAXHP : 0.0f;
		redBar.sizeDelta = Vector2.Lerp(redBar.sizeDelta, new Vector2(width * delta, redBar.sizeDelta.y), Time.deltaTime / 0.01f);
	}
}