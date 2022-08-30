using UnityEngine;

public class BossHealth : MonoBehaviour
{
	[SerializeField]
	private RectTransform redBar;

	private Stats bossStats;

	private float width;

	void Start()
	{
		bossStats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Boss>().stats;

		width = redBar.sizeDelta.x;
	}

	void Update()
	{
		float bossDelta = Mathf.Abs(1.0f * bossStats.HP / bossStats.MaxHP);
		redBar.sizeDelta = Vector2.Lerp(redBar.sizeDelta, new Vector2(width * bossDelta, redBar.sizeDelta.y), 100.0f * Time.deltaTime);
	}
}