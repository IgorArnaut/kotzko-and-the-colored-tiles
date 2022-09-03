using UnityEngine;

public class KeyGate : Gate
{
	// Inventory
	[SerializeField] 
	private Inventory playerInventory;

	// Unlocks gate
	public override void Unlock()
	{
		if (playerInventory.KEYS > 0 && locked)
		{
			playerInventory.KEYS--;
			locked = false;
			src.PlayOneShot(clips[0]);
		}
	}
}
