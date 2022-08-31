using UnityEngine;

public class MinionIdle : StateMachineBehaviour
{
	private SpriteRenderer sr;
	private Transform transform;

	private GameObject player;

	[SerializeField]
	private float distance;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		sr = animator.gameObject.GetComponent<SpriteRenderer>();
		transform = animator.gameObject.transform;

		Init();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (player != null)
		{
			Vector2 playerPos = player.transform.position;

			if (transform.position.x > playerPos.x)
				sr.flipX = true;

			if (transform.position.x < playerPos.x)
				sr.flipX = false;

			animator.SetBool("walk", Vector2.Distance(transform.position, playerPos) < distance);
		}
	}

	private void Init()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
}
