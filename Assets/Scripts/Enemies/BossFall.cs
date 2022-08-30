using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFall : StateMachineBehaviour
{
	private Animator anim;
	private CapsuleCollider2D cc;

	[SerializeField]
	private LayerMask ground;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;
		cc = animator.gameObject.GetComponent<CapsuleCollider2D>();

		Init();
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (IsGrounded())
			anim.SetTrigger("dead");
	}

	private void Init()
	{
		anim.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5.0f;   
	}

	private bool IsGrounded()
	{
		RaycastHit2D rc = Physics2D.CapsuleCast(cc.bounds.center, cc.bounds.size, CapsuleDirection2D.Horizontal, 0.0f, Vector2.down, 0.1f, ground);
		Debug.Log(rc.collider);
		return rc.collider != null;
	}
}
