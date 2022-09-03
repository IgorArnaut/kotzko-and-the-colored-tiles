using UnityEngine;

public class Minion : Enemy
{
	// Components
	private Animator anim;

	protected override void Awake()
	{
		GetComponents();
	}

	override protected void Update()
	{
		base.Update();
		EnemyHealth.bar.ResizeHealthBar(stats.HP, stats.MAXHP);
	}

	// Gets Components
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
	}

	// Dies
	override protected void Die()
	{
		if (stats.IsDead()) anim.SetTrigger("dead");
	}
}
