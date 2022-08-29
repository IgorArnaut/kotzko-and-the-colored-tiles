using System.Collections.Generic;
using UnityEngine;

public class BossStrike : StateMachineBehaviour
{
	private Animator anim;
	private CapsuleCollider2D cc;
	private SpriteRenderer sr;
	private Transform transform;
	
	private GameObject player;

	private Stats stats;
	[SerializeField]
	private Stats playerStats;

	[SerializeField]
	private List<Vector2> targets;
	private Vector2 target;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;
		cc = animator.gameObject.GetComponent<CapsuleCollider2D>();
		sr = animator.gameObject.GetComponent<SpriteRenderer>();
		transform = animator.gameObject.transform;
		
		player = GameObject.FindGameObjectWithTag("Player");
		
		stats = animator.gameObject.GetComponent<Boss>().stats;
		
		cc.isTrigger = true;

		target = targets[Random.Range(0, targets.Count)];
		
		animator.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
	}

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MoveToTarget();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		cc.isTrigger = false;
	}

	private void MoveToTarget()
	{
		if (transform.position.x > target.x)
			sr.flipX = true;

		if (transform.position.x < target.x)
			sr.flipX = false;

		Vector2 delta = Vector2.Lerp(transform.position, target, Time.deltaTime * stats.speed * 2.0f);
		transform.position = delta;
		anim.SetFloat("horizontal", delta.normalized.x);
		anim.SetFloat("vertical", delta.normalized.y);

		if (player != null)
			HurtPlayer();

		anim.SetBool("strike", Vector2.Distance(transform.position, target) == 0.0f);
	}

	private void HurtPlayer() {
		bool playerCollided = anim.gameObject.GetComponent<Enemy>().playerCollided;

		if (playerCollided)
		{
			player.GetComponent<Animator>().SetTrigger("hurt");
			playerStats.TakeDamge(stats.ATK);
		}
	}
}
