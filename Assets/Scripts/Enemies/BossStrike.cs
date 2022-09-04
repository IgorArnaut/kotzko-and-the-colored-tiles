using UnityEngine;

public class BossStrike : StateMachineBehaviour
{
	// Komponente
	private Animator anim;
	private AudioSource src;
	private Enemy enemy;
	private SpriteRenderer sr;
	private Transform transform;

	// Povredjivanje igraca
	private GameObject player;
	[SerializeField]
	private BoolValue defend;
	[SerializeField]
	private Stats playerStats;

	// Napad
	private Stats stats;
	[SerializeField]
	private AudioClip[] clips;
	private Vector2 target;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
		src.PlayOneShot(clips[0]);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Strike();
		DamagePlayer();
	}

	// Uzima komponente
	private void GetComponents(Animator animator)
	{
		anim = animator;
		src = anim.gameObject.GetComponent<AudioSource>();
		enemy = anim.gameObject.GetComponent<Enemy>();
		sr = anim.gameObject.GetComponent<SpriteRenderer>();
		transform = anim.gameObject.transform;
	}

	// Inicira neke vredosti
	private void Init()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		stats = enemy.stats;
		target = player.transform.position;
	}

	// Poleti do igraca 
	private void Strike()
	{
		Vector2 delta = Vector2.MoveTowards(transform.position, target, Time.deltaTime * stats.SPEED * 5.0f);
		transform.position = delta;
		if (transform.position.x > target.x) sr.flipX = true; 
		if (transform.position.x < target.x) sr.flipX = false;
		anim.SetFloat("horizontal", delta.normalized.x);
		anim.SetFloat("vertical", delta.normalized.y);
		anim.SetBool("strike", Vector2.Distance(transform.position, target) == 0.0f);
	}

	// Povredjuje igraca
	private void DamagePlayer() {
		bool playerCollided = enemy.playerCollided;

		if (playerCollided && player != null)
		{
			if (!defend.value) player.GetComponent<Animator>().SetTrigger("hurt"); else src.PlayOneShot(clips[1]);
			playerStats.TakeDamge((int)(1.0f));
		}
	}
}
