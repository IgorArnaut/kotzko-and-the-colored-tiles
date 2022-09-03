using UnityEngine;

public class Death : StateMachineBehaviour
{
	// Components
	private Rigidbody2D rb2D;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
	}

	// Gets components
	private void GetComponents(Animator animator)
	{
		rb2D = animator.gameObject.GetComponent<Rigidbody2D>();
	}

	// Initializes values
	private void Init()
	{
		rb2D.bodyType = RigidbodyType2D.Static;
	}
}
