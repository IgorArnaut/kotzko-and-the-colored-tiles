using UnityEngine;

public class KeyGate : Gate
{
	[SerializeField] 
	private Inventory playerInventory;

	public override void Unlock()
	{
		if (playerInventory.keys > 0 && locked)
		{
			locked = false;
			playerInventory.keys -= 1;
		}
	}
}
