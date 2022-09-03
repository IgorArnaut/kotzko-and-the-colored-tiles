using UnityEngine;

public class MinionIdle : StateMachineBehaviour
{
	// Components
	private Animator anim;
	private SpriteRenderer sr;
	private Transform transform;

	// Stand
	private GameObject player;
	[SerializeField]
	private float distance;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Stand();
	}

	// Gets Components
	private void GetComponents(Animator animator)
	{
		anim = animator;
		sr = anim.gameObject.GetComponent<SpriteRenderer>();
		transform = anim.gameObject.transform;
	}

	// Initializes values
	private void Init()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Stands
	private void Stand()
	{
		if (player != null)
		{
			Vector2 playerPos = player.transform.position;
			if (transform.position.x > playerPos.x) sr.flipX = true;
			if (transform.position.x < playerPos.x) sr.flipX = false;
			anim.SetBool("walk", Vector2.Distance(transform.position, playerPos) < distance);
		}
	}
}
