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
			src.PlayOneShot(clips[0]);
			playerInventory.bossKey--;
		}
	}
}
