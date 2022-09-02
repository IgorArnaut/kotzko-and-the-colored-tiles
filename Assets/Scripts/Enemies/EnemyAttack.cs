using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
	// Components
	private Animator anim;
	private AudioSource src;
	private Enemy enemy;

	// Attack
	private Stats stats;

	// Damage Player
	[SerializeField]
	private AudioClip clip;
	private GameObject player;
	[SerializeField]
	private BoolValue defend;
	[SerializeField]
	private Stats playerStats;
	private bool playerCollided;


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		playerCollided = enemy.playerCollided;
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		DamagePlayer();
	}

	// Get Components
	private void GetComponents(Animator animator)
	{
		anim = animator;
		src = anim.gameObject.GetComponent<AudioSource>();
		enemy = anim.gameObject.GetComponent<Enemy>();
	}

	// Initialize
	private void Init()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		stats = enemy.stats;
	}

	// Damage Player
	private void DamagePlayer()
	{
		if (playerCollided && !playerStats.IsDead() && player != null)
		{
			if (!defend.value) player.GetComponent<Animator>().SetTrigger("hurt");
			else src.PlayOneShot(clip);
			playerStats.TakeDamge(stats.ATK);
		}
	}
}