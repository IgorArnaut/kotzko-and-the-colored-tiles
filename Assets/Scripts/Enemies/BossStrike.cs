using UnityEngine;

public class BossStrike : StateMachineBehaviour
{
	// Components
	private Animator anim;
	private AudioSource src;
	private Enemy enemy;
	private SpriteRenderer sr;
	private Transform transform;

	// Damage Player
	private GameObject player;
	[SerializeField]
	private BoolValue defend;
	[SerializeField]
	private Stats playerStats;

	// Fly
	private Stats stats;
	[SerializeField]
	private AudioClip[] clips;
	private Vector2 target;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Fly();
		DamagePlayer();
	}

	// Get Components
	private void GetComponents(Animator animator)
	{
		anim = animator;
		src = anim.gameObject.GetComponent<AudioSource>();
		enemy = anim.gameObject.GetComponent<Enemy>();
		sr = anim.gameObject.GetComponent<SpriteRenderer>();
		transform = anim.gameObject.transform;
	}

	// Initialize
	private void Init()
	{
		src.PlayOneShot(clips[0]);
		player = GameObject.FindGameObjectWithTag("Player");
		stats = enemy.stats;
		target = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
	}

	// Fly
	private void Fly()
	{
		if (transform.position.x > target.x) sr.flipX = true; 
		if (transform.position.x < target.x) sr.flipX = false;
		Vector2 delta = Vector2.Lerp(transform.position, target, Time.deltaTime * stats.SPEED * 5.0f);
		transform.position = delta;
		anim.SetFloat("horizontal", delta.normalized.x);
		anim.SetFloat("vertical", delta.normalized.y);
		anim.SetBool("strike", Vector2.Distance(transform.position, target) == 0.0f);
	}

	// Damage Player
	private void DamagePlayer() {
		bool playerCollided = enemy.playerCollided;

		if (playerCollided && player != null)
		{
			if (!defend.value) player.GetComponent<Animator>().SetTrigger("hurt");
			else src.PlayOneShot(clips[1]);
			playerStats.TakeDamge((int)(1.0f));
		}
	}
}
