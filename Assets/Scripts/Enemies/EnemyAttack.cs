using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
	private Animator anim;

	private GameObject player;
	private bool playerCollided;

	private Stats stats;
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
		player = GameObject.FindGameObjectWithTag("Player");
		playerCollided = anim.gameObject.GetComponent<Enemy>().playerCollided;
		stats = anim.gameObject.GetComponent<Enemy>().stats;
	}

	private void HurtPlayer()
	{
		if (playerCollided && player != null)
		{
			player.GetComponent<Animator>().SetTrigger("hurt");
			playerStats.TakeDamge(stats.ATK);
		}
	}
}