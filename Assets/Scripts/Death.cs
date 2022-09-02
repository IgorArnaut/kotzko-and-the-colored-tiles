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

	private void GetComponents(Animator animator)
	{
		rb2D = animator.gameObject.GetComponent<Rigidbody2D>();
	}

	// Initialize
	private void Init()
	{
		rb2D.bodyType = RigidbodyType2D.Static;
	}
}
