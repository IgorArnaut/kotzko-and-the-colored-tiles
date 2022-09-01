using UnityEngine;

public class KeyGate : Gate
{
	[SerializeField] 
	private Inventory playerInventory;

	public override void Unlock()
	{
		if (playerInventory.KEYS > 0 && locked)
		{
			locked = false;
			GetComponent<AudioSource>().PlayOneShot(clips[0]);
			playerInventory.KEYS--;
		}
	}
}
