using UnityEngine;

public class Minion : Enemy
{
	// Komponente
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

	// Uzima komponente
	private void GetComponents()
	{
		anim = GetComponent<Animator>();
	}

	// Umire
	override protected void Die()
	{
		if (stats.IsDead()) anim.SetTrigger("dead");
	}
}
