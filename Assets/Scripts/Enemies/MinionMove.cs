using UnityEngine;

public class MinionMove : StateMachineBehaviour
{
	// Components
	private Animator anim;
	private Enemy enemy;
	private SpriteRenderer sr;
	private Transform transform;

	// Follow Player
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

	// Gets Components
	private void GetComponents(Animator animator)
	{
		anim = animator;
		enemy = anim.gameObject.GetComponent<Enemy>();
		sr = anim.gameObject.GetComponent<SpriteRenderer>();
		transform = anim.gameObject.transform;
	}

	// Initializes values
	private void Init()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		stats = enemy.stats;
	}

	// Follows player
	private void FollowPlayer()
	{
		bool playerCollided = enemy.playerCollided;

		if (!playerCollided)
		{
			Vector2 playerPos = player.transform.position;
			if (transform.position.x > playerPos.x) sr.flipX = true;
			if (transform.position.x < playerPos.x)	sr.flipX = false;
			transform.position = Vector2.MoveTowards(transform.position, playerPos, stats.SPEED * Time.deltaTime);
			anim.SetBool("walk", Vector2.Distance(transform.position, playerPos) < distance);
		}

		if (playerCollided && player != null) anim.SetTrigger("attack");
	}
}
