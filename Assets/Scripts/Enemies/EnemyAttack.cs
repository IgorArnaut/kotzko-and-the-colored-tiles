using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
	private Animator anim;

	private Stats stats;

	private GameObject player;
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private BoolValue defend;
	private bool playerCollided;

	[SerializeField]
	private AudioClip clip;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;

		Init();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		playerCollided = anim.gameObject.GetComponent<Enemy>().playerCollided;
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
		if (playerCollided && !playerStats.IsDead() && player != null)
		{
			if (!defend.value)
				player.GetComponent<Animator>().SetTrigger("hurt");
			else
				anim.GetComponent<AudioSource>().PlayOneShot(clip);

			playerStats.TakeDamge(stats.ATK);
		}
	}
}