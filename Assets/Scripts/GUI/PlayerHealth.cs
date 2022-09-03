using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealthBar
{
	public static PlayerHealth bar;

	// Health bar
	[SerializeField]
	private Animator face;
	[SerializeField]
	private RectTransform greenBar;
	private float width;

	void Awake()
	{
		bar = this;
	}

	void Start()
	{
		width = greenBar.sizeDelta.x;
	}

	// Resizes player health bar
	public void ResizeHealthBar(int HP, int MAXHP)
	{
		float delta = HP > 0.0f ? 1.0f * HP / MAXHP : 0.0f;
		face.SetFloat("health", delta);
		greenBar.sizeDelta = Vector2.Lerp(greenBar.sizeDelta, new Vector2(width * delta, greenBar.sizeDelta.y), Time.deltaTime / 0.01f);
	}
}