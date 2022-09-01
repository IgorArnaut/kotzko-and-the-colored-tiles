using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	[SerializeField]
	private Stats playerStats;

	[SerializeField]
	private RectTransform greenBar;
	private float width;

	[SerializeField]
	private Animator face;

	void Start()
	{
		width = greenBar.sizeDelta.x;
	}

	void Update()
	{
		ReziseHealthBar();
	}

	private void ReziseHealthBar()
	{
		float playerDelta = playerStats.HP > 0.0f ? 1.0f * playerStats.HP / playerStats.MAXHP : 0.0f;

		greenBar.sizeDelta = Vector2.Lerp(greenBar.sizeDelta, new Vector2(width * playerDelta, greenBar.sizeDelta.y), 100.0f * Time.deltaTime);
		face.SetFloat("health", playerDelta);
	}
}