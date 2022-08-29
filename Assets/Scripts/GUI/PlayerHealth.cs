using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField]
	private RectTransform greenBar;
	[SerializeField]
	private Animator face;

	[SerializeField]
	private Stats playerStats;

	private float width;

	void Start()
	{
		width = greenBar.sizeDelta.x;
	}

	void Update()
	{
		float playerDelta = playerStats.HP > 0.0f ? 1.0f * playerStats.HP / playerStats.MaxHP : 0.0f;

		greenBar.sizeDelta = new Vector2(width * playerDelta, greenBar.sizeDelta.y);
		face.SetFloat("health", playerDelta);
	}
}