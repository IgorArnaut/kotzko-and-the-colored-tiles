using UnityEngine;

public class KeyGate : Gate
{
	// Kljuc
	[SerializeField] 
	private Inventory playerInventory;

	// Otkljucava kapiju
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
