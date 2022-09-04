using UnityEngine;

public class MinionIdle : StateMachineBehaviour
{
	// Komponente
	private Animator anim;
	private SpriteRenderer sr;
	private Transform transform;

	// Stajanje
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

	// Uzima komponente
	private void GetComponents(Animator animator)
	{
		anim = animator;
		sr = anim.gameObject.GetComponent<SpriteRenderer>();
		transform = anim.gameObject.transform;
	}

	// Inicira neke vrednosti
	private void Init()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Stoji
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
