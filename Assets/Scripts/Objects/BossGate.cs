using UnityEngine;

public class BossGate : Gate
{
	// Boss kljuc
	[SerializeField]
	private Inventory playerInventory;

	// Otkljucava kapiju
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
