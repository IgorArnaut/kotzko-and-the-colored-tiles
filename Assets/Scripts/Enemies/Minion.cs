using UnityEngine;

public class Minion : Enemy
{
	// Components
	private Animator anim;

	// Health bar
	[SerializeField]
	private Transform redBar;
	private float width;

	protected override void Awake()
	{
		GetComponents();
	}

    override protected void Start()
	{
		base.Start();
        width = redBar.localScale.x;
	}

	override protected void Update()
	{
		base.Update();
		ResizeHealthBar();
	}

	// Get Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
	}

	override protected void Die()
	{
		if (stats.IsDead()) anim.SetTrigger("dead");
	}

	// Health bar
	private void ResizeHealthBar()
	{
		float delta = stats.HP > 0.0f ? Mathf.Abs(1.0f * stats.HP / stats.MAXHP) : 0.0f;
		redBar.localScale = Vector2.Lerp(redBar.localScale, new Vector2(delta * width, redBar.localScale.y), 100.0f * Time.deltaTime);
	}
}
