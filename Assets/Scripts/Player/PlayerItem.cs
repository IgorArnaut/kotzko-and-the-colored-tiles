using UnityEngine;

public class PlayerItem : StateMachineBehaviour
{
	// Components
	private Rigidbody2D rb2D;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		rb2D.bodyType = RigidbodyType2D.Dynamic;
	}

	// Gets Components
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
