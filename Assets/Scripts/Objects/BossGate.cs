using UnityEngine;

public class BossGate : Gate
{
	[SerializeField]
	private Inventory playerInventory;

	public override void Unlock()
	{
		if (playerInventory.BOSSKEY > 0 && locked)
		{
			locked = false;
			GetComponent<AudioSource>().PlayOneShot(clips[0]);
			playerInventory.BOSSKEY--;
		}
	}
}
