using UnityEngine;

public class BossGate : Gate
{
	// Inventory
	[SerializeField]
	private Inventory playerInventory;

	// Unlock
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
