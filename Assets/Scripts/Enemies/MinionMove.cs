using UnityEngine;

public class MinionMove : StateMachineBehaviour
{
	private Animator anim;
	private SpriteRenderer sr;
	private Transform transform;

	private Stats stats;

	private GameObject player;

	[SerializeField]
	private float distance;
	private bool playerCollided;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;
		sr = animator.gameObject.GetComponent<SpriteRenderer>();
		transform = animator.gameObject.transform;

		stats = animator.gameObject.GetComponent<Minion>().stats;

		player = GameObject.FindGameObjectWithTag("Player");
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (player != null)
			Move();
	}

	private void Move()
	{
		playerCollided = anim.gameObject.GetComponent<Enemy>().playerCollided;

		if (!playerCollided)
		{
			Vector2 playerPos = player.transform.position;

			if (transform.position.x > playerPos.x)
				sr.flipX = true;

			if (transform.position.x < playerPos.x)
				sr.flipX = false;

			transform.position = Vector2.MoveTowards(transform.position, playerPos, stats.speed * Time.deltaTime);
			anim.SetBool("walk", Vector2.Distance(transform.position, playerPos) < distance);
		}
		
		if (playerCollided)
			anim.SetTrigger("attack");
	}
}