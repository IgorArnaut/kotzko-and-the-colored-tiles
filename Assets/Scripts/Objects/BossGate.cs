using UnityEngine;

public class BossGate : Gate
{
	[SerializeField]
	private Inventory playerInventory;

	public override void Unlock()
	{
		if (playerInventory.bossKey > 0 && locked)
		{
			locked = false;
			playerInventory.bossKey -= 1;
		}
	}
}
