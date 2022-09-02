using UnityEngine;

public class KeyChest : Chest
{
	// Item
	[SerializeField]
	private GameObject key;

	// Give items
	public override void GiveItems() 
	{
		key = Instantiate(key, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		playerInventory.KEYS++;
		StartCoroutine(Write("You have obtained a key!", key));
		PlayerItem();
	}
}