using UnityEngine;

public class PlayerItem : StateMachineBehaviour
{
	// Komponente
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
