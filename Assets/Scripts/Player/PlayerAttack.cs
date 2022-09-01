using UnityEngine;

public class PlayerAttack : StateMachineBehaviour
{
	private Animator anim;

	[SerializeField]
	private Stats stats;

	private GameObject enemy;
	private bool enemyCollided;
	private Stats enemyStats;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		enemyCollided = anim.gameObject.GetComponent<PlayerBattle>().enemyCollided;
		enemy = anim.gameObject.GetComponent<PlayerBattle>().enemy;
		
		if (enemy != null)
			enemyStats = enemy.GetComponent<Enemy>().stats;
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		HurtEnemy();
	}

	private void HurtEnemy()
	{
		if (enemyCollided && !enemyStats.IsDead() && enemy != null)
		{
			enemy.GetComponent<Animator>().SetTrigger("hurt");
			enemyStats.TakeDamge(stats.ATK);
		}
	}
}
