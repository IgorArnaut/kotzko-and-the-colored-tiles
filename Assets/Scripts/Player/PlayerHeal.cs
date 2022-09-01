using UnityEngine;

public class PlayerHeal : StateMachineBehaviour
{
	[SerializeField]
	private Stats stats;
	[SerializeField]
	private Inventory inventory;

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Heal();
	}

	private void Heal()
	{
		if (inventory.hearts > 0)
		{
			inventory.hearts--;
			stats.Heal(10);
		}
	}
}
