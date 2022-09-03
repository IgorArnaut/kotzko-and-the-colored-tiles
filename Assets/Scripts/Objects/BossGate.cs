using UnityEngine;

public class BossGate : Gate
{
	// Inventory
	[SerializeField]
	private Inventory playerInventory;

	// Unlocks gate
	public override void Unlock()
	{
		if (playerInventory.BOSSKEY > 0 && locked)
		{
			playerInventory.BOSSKEY--;
			locked = false;
			src.PlayOneShot(clips[0]);
		}
	}
}
