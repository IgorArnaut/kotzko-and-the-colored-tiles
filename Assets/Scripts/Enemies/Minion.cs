using UnityEngine;

public class Minion : Enemy
{
	[SerializeField]
	private Transform redBar;
	private float width;

    override protected void Start()
	{
		base.Start();
		
        width = redBar.localScale.x;
	}

	override protected void Die()
	{
		if (stats.IsDead())
			anim.SetTrigger("dead");
	}

	override protected void Update()
	{
        base.Update();

		float delta = stats.HP > 0.0f ? Mathf.Abs(1.0f * stats.HP / stats.MaxHP) : 0.0f;
		redBar.localScale = Vector2.Lerp(redBar.localScale, new Vector2(delta * width, redBar.localScale.y), 100.0f * Time.deltaTime);
	}
}
