using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
	private Animator anim;

	private GameObject player;

	private Stats stats;
	[SerializeField]
	private Stats playerStats;


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;

		player = GameObject.FindGameObjectWithTag("Player");

		stats = animator.gameObject.GetComponent<Enemy>().stats;

		if (player != null)
			HurtPlayer();
	}

	private void HurtPlayer()
	{
		bool playerCollided = anim.gameObject.GetComponent<Enemy>().playerCollided;

		if (playerCollided && player != null)
		{
			player.GetComponent<Animator>().SetTrigger("hurt");
			playerStats.TakeDamge(stats.ATK);
		}
	}
}