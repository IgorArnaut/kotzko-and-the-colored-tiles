using System.Collections.Generic;
using UnityEngine;

public class BossStrike : StateMachineBehaviour
{
	private Animator anim;
	private SpriteRenderer sr;
	private Transform transform;
	
	private Stats stats;

	private GameObject player;
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private BoolValue defend;

	[SerializeField]
	private AudioClip[] clips;

	[SerializeField]
	private List<Vector2> targets;
	private Vector2 target;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;
		sr = animator.gameObject.GetComponent<SpriteRenderer>();
		transform = animator.gameObject.transform;

		Init();
		anim.GetComponent<AudioSource>().PlayOneShot(clips[0]);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MoveToTarget();
		HurtPlayer();
	}

	private void Init()
	{
		stats = anim.gameObject.GetComponent<Boss>().stats;
		player = GameObject.FindGameObjectWithTag("Player");
		target = targets[Random.Range(0, targets.Count)];
	}

	private void MoveToTarget()
	{
		if (transform.position.x > target.x)
			sr.flipX = true;

		if (transform.position.x < target.x)
			sr.flipX = false;

		Vector2 delta = Vector2.Lerp(transform.position, target, Time.deltaTime * stats.SPEED * 4.0f);
		transform.position = delta;
		anim.SetFloat("horizontal", delta.normalized.x);
		anim.SetFloat("vertical", delta.normalized.y);

		anim.SetBool("strike", Vector2.Distance(transform.position, target) == 0.0f);
	}

	private void HurtPlayer() {
		bool playerCollided = anim.gameObject.GetComponent<Enemy>().playerCollided;

		if (playerCollided && player != null)
		{

			if (!defend.value)
				player.GetComponent<Animator>().SetTrigger("hurt");
			else
				anim.GetComponent<AudioSource>().PlayOneShot(clips[1]);


			playerStats.TakeDamge((int)(1.0f));
		}
	}
}
