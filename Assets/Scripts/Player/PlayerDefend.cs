using UnityEngine;

public class PlayerDefend : StateMachineBehaviour
{
	// Odbrana
	[SerializeField]
	private Stats stats;
	private int temp;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		temp = stats.DEF;
		stats.DEF = (int)(stats.DEF * 1.25f);
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		stats.DEF = temp;
	}
}
