using UnityEngine;

public class BossChest : Chest
{
	// Item
	[SerializeField]
	private GameObject bossKey;

	// Give items
	public override void GiveItems()
	{
		bossKey = Instantiate(bossKey, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		if (playerInventory.BOSSKEY < 1) playerInventory.BOSSKEY++;
		StartCoroutine(Write("You have obtained a boss key!", bossKey));
		PlayerItem();
	}
}