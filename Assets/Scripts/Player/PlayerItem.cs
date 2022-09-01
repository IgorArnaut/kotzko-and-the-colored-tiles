using UnityEngine;

public class PlayerItem : StateMachineBehaviour
{
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
	}
}
