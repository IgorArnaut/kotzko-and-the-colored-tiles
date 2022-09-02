using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	// Player stats
	[SerializeField]
	private Stats playerStats;

	// Health bar
	[SerializeField]
	private Animator face;
	[SerializeField]
	private RectTransform greenBar;
	private float width;

	void Start()
	{
		width = greenBar.sizeDelta.x;
	}

	void Update()
	{
		ReziseHealthBar();
	}

	// Health bar
	private void ReziseHealthBar()
	{
		float playerDelta = playerStats.HP > 0.0f ? 1.0f * playerStats.HP / playerStats.MAXHP : 0.0f;
		face.SetFloat("health", playerDelta);
		greenBar.sizeDelta = Vector2.Lerp(greenBar.sizeDelta, new Vector2(width * playerDelta, greenBar.sizeDelta.y), Time.deltaTime / 0.01f);
	}
}