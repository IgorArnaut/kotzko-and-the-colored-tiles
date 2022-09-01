using UnityEngine;

public class KeyChest : Chest
{
	[SerializeField]
	private GameObject key;

	public override void GiveItems() 
	{
		key = Instantiate(key, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		StartCoroutine(Write("You have obtained a key!", key));
		playerInventory.KEYS++;
	}
}