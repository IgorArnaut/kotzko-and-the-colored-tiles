using UnityEngine;

public class BossFall : StateMachineBehaviour
{
	// Components
	private Animator anim;
	private AudioSource src;
	private CapsuleCollider2D cc2D;
	private Enemy enemy;
	private Rigidbody2D rb2D;

	// Death
	[SerializeField]
	private AudioClip clip;
	[SerializeField]
	private LayerMask ground;
	private Stats stats;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
		src.PlayOneShot(clip);
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (IsGrounded()) anim.SetTrigger("dead");
	}

	// Gets Components
	private void GetComponents(Animator animator)
	{
		anim = animator;
		src = anim.GetComponent<AudioSource>();
		cc2D = anim.gameObject.GetComponent<CapsuleCollider2D>();
		enemy = anim.gameObject.GetComponent<Enemy>();
		rb2D = anim.gameObject.GetComponent<Rigidbody2D>();
	}

	// Initializes values
	private void Init()
	{
		rb2D.gravityScale = 5.0f;
		stats = enemy.stats;
		stats.HP = 1;

	}

	// Checks if boss is grounded
	private bool IsGrounded()
	{
		RaycastHit2D rc = Physics2D.CapsuleCast(cc2D.bounds.center, cc2D.bounds.size, CapsuleDirection2D.Horizontal, 0.0f, Vector2.down, 0.1f, ground);
		return rc.collider != null;
	}
}
