using UnityEngine;

public class Death : StateMachineBehaviour
{
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
	}
}
