using UnityEngine;

public class PlayerHeal : StateMachineBehaviour
{
	// Lecenje
	[SerializeField]
	private Stats stats;
	[SerializeField]
	private Inventory inventory;

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Heal();
	}

	// Leci igraca
	private void Heal()
	{
		if (inventory.HEARTS > 0)
		{
			inventory.HEARTS--;
			stats.Heal(20);
		}
	}
}
