using UnityEngine;

public class Death : StateMachineBehaviour
{
	// Komponente
	private Rigidbody2D rb2D;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GetComponents(animator);
		Init();
	}

	// Uzima komponente
	private void GetComponents(Animator animator)
	{
		rb2D = animator.gameObject.GetComponent<Rigidbody2D>();
	}

	// Inicijalizuje neke vrednosti
	private void Init()
	{
		rb2D.bodyType = RigidbodyType2D.Static;
	}
}
