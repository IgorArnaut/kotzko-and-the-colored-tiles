using UnityEngine;

public class BossFall : StateMachineBehaviour
{
	private Animator anim;
	private CapsuleCollider2D cc;

	private Stats stats;

	[SerializeField]
	private AudioClip clip;

	[SerializeField]
	private LayerMask ground;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		anim = animator;
		cc = animator.gameObject.GetComponent<CapsuleCollider2D>();

		Init();
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (IsGrounded())
			anim.SetTrigger("dead");
	}

	private void Init()
	{
		anim.GetComponent<AudioSource>().PlayOneShot(clip);
		anim.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5.0f;

		stats = anim.gameObject.GetComponent<Enemy>().stats;
		stats.HP = 1;
	}

	private bool IsGrounded()
	{
		RaycastHit2D rc = Physics2D.CapsuleCast(cc.bounds.center, cc.bounds.size, CapsuleDirection2D.Horizontal, 0.0f, Vector2.down, 0.1f, ground);
		Debug.Log(rc.collider);
		return rc.collider != null;
	}
}
