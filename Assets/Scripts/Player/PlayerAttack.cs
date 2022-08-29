using UnityEngine;

public class PlayerAttack : StateMachineBehaviour
{
	private Animator anim;

	private GameObject enemy;

	[SerializeField]
	private Stats stats;
	private Stats enemyStats;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;

		enemy = animator.gameObject.GetComponent<PlayerBattle>().enemy;

		if (enemy != null) {
			enemyStats = enemy.GetComponent<Enemy>().stats;
			HurtEnemy();
		}
	}

	private void HurtEnemy()
	{
		bool enemyCollided = anim.gameObject.GetComponent<PlayerBattle>().enemyCollided;

		if (enemyCollided)
		{
			enemy.GetComponent<Animator>().SetTrigger("hurt");
			enemyStats.TakeDamge(stats.ATK);
		}
	}
}
