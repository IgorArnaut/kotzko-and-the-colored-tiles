using UnityEngine;

public class BossMove : StateMachineBehaviour
{
	private Animator anim;
	private SpriteRenderer sr;
	private Transform transform;

	private Stats stats;

	private GameObject player;

	[SerializeField]
	private float distance;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;
		sr = animator.gameObject.GetComponent<SpriteRenderer>();
		transform = animator.gameObject.transform;

		Init();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (player != null)
			Move();
		else
			anim.SetBool("walk", false);
	}

	private void Init()
	{
		stats = anim.gameObject.GetComponent<Boss>().stats;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void Move()
	{
		bool playerCollided = anim.gameObject.GetComponent<Enemy>().playerCollided;

		if (!playerCollided)
		{
			Vector2 playerPos = player.transform.position;

			if (transform.position.x > playerPos.x)
				sr.flipX = true;

			if (transform.position.x < playerPos.x)
				sr.flipX = false;

			transform.position = Vector2.MoveTowards(transform.position, playerPos, stats.SPEED * Time.deltaTime);
			anim.SetBool("walk", Vector2.Distance(transform.position, playerPos) < distance);
		}

		if (playerCollided && player != null)
			Attack();
	}

	private void Attack() {
		int rnd = Random.Range(0, 2);

		if (rnd == 0)
			anim.SetTrigger("attack");

		if (rnd == 1)
			anim.SetTrigger("attack2");
	}
}
