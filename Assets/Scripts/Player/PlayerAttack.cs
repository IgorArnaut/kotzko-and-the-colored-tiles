using UnityEngine;

public class PlayerAttack : StateMachineBehaviour
{
	private Animator anim;

	[SerializeField]
	private Stats stats;

	private GameObject enemy;
	private Stats enemyStats;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;

		Init();
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		HurtEnemy();
	}

	private void Init()
	{
		enemy = anim.gameObject.GetComponent<PlayerBattle>().enemy;

		if (enemy != null)
			enemyStats = enemy.GetComponent<Enemy>().stats;
	}

	private void HurtEnemy()
	{
		bool enemyCollided = anim.gameObject.GetComponent<PlayerBattle>().enemyCollided;

		if (enemyCollided && enemy != null)
		{
			enemy.GetComponent<Animator>().SetTrigger("hurt");
			enemyStats.TakeDamge(stats.ATK);
		}
	}
}
