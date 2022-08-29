using UnityEngine;

public class BossHealth : MonoBehaviour
{
	private RectTransform redBar;

	private Stats bossStats;

	private float width;

	void Start()
	{
		redBar = transform.GetChild(0).GetComponent<RectTransform>();

		bossStats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Boss>().stats;

		width = redBar.sizeDelta.x;
	}

	void Update()
	{
		float bossDelta = Mathf.Abs(1.0f * bossStats.HP / bossStats.MaxHP);
		Debug.Log(bossDelta);
		redBar.sizeDelta = new Vector2(width * bossDelta, redBar.sizeDelta.y);
	}
}