using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
	private Animator anim;

	private Stats stats;

	private GameObject player;
	[SerializeField]
	private Stats playerStats;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;

		Init();
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		HurtPlayer();
	}

	private void Init()
	{
		stats = anim.gameObject.GetComponent<Enemy>().stats;
		player = GameObject.FindGameObjectWithTag("Player");
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