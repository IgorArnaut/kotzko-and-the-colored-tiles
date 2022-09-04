using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealthBar
{
	// Instanca
	public static EnemyHealth bar;

	// Linija
	private float width;

	void Awake()
	{
		bar = this;
	}

	void Start()
	{
		width = transform.localScale.x;
	}

	// Menja duzinu linije
	public void ResizeHealthBar(int HP, int MAXHP)
	{
		float delta = HP > 0.0f ? 1.0f * HP / MAXHP : 0.0f;
		transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(width * delta, transform.localScale.y), Time.deltaTime / 0.01f);
	}
}