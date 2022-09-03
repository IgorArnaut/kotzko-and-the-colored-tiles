using UnityEngine;

public class PlayerAttack : StateMachineBehaviour
{
	// Components
	private Animator anim;
	private PlayerBattle pb;

	// Stats
	[SerializeField]
	private Stats stats;

	// Enemy
	private GameObject enemy;
	private Stats enemyStats;
	private bool enemyCollided;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		enemyCollided = pb.enemyCollided;
		enemy = pb.enemy;
		if (enemy != null) enemyStats = enemy.GetComponent<Enemy>().stats;
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		DamageEnemy();
	}

	// Gets Components
	private void GetComponents(Animator animator)
	{
		anim = animator;
		pb = anim.gameObject.GetComponent<PlayerBattle>();
	}

	// Damages Enemy
	private void DamageEnemy()
	{
		if (enemyCollided && !enemyStats.IsDead() && enemy != null)
		{
			enemy.GetComponent<Animator>().SetTrigger("hurt");
			enemyStats.TakeDamge(stats.ATK);
		}
	}
}
