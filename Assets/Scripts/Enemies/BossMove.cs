using UnityEngine;

public class BossMove : StateMachineBehaviour
{
	// Komponente
	private Animator anim;
	private Enemy enemy;
	private SpriteRenderer sr;
	private Transform transform;

	// Pracenje igraca
	private GameObject player;
	private Stats stats;
	[SerializeField]
	private float distance;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (player != null) FollowPlayer();	else anim.SetBool("walk", false);
	}

	// Uzima komponente
	private void GetComponents(Animator animator)
	{
		anim = animator;
		enemy = anim.gameObject.GetComponent<Enemy>();
		sr = anim.gameObject.GetComponent<SpriteRenderer>();
		transform = anim.gameObject.transform;
	}

	// Inicira neke vrednosti
	private void Init()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		stats = enemy.stats;
		Debug.Log(stats);
	}

	// Prati igraca
	private void FollowPlayer()
	{
		bool playerCollided = enemy.playerCollided;

		if (!playerCollided)
		{
			Vector2 playerPos = player.transform.position;
			if (transform.position.x > playerPos.x) sr.flipX = true;
			if (transform.position.x < playerPos.x)	sr.flipX = false;
			transform.position = Vector2.MoveTowards(transform.position, playerPos, stats.SPEED * Time.deltaTime);
			anim.SetFloat("horizontal", transform.position.x - playerPos.x);
			anim.SetBool("walk", Vector2.Distance(transform.position, playerPos) < distance);
		}

		if (playerCollided && player != null) Attack();
	}

	// Napada igraca
	private void Attack() {
		int rnd = Random.Range(0, 2);
		if (rnd == 0) anim.SetTrigger("attack");
		if (rnd == 1) anim.SetTrigger("attack2");
	}
}
