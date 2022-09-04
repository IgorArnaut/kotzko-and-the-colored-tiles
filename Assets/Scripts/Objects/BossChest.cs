using UnityEngine;

public class BossChest : Chest
{
	// Boss key
	[SerializeField]
	private GameObject bossKey;

	// Gives a boss key
	override protected void GiveItems()
	{
		base.GiveItems();
		if (playerInventory.BOSSKEY < 1) playerInventory.BOSSKEY++;
		bossKey = Instantiate(bossKey, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		StartCoroutine(Write("You have obtained a boss key!", bossKey));
	}
}