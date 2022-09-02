using UnityEngine;

public class PlayerHeal : StateMachineBehaviour
{
	// Heal
	[SerializeField]
	private Stats stats;
	[SerializeField]
	private Inventory inventory;

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Heal();
	}

	// Heal
	private void Heal()
	{
		if (inventory.HEARTS > 0)
		{
			inventory.HEARTS--;
			stats.Heal(20);
		}
	}
}
