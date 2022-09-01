using UnityEngine;

public class BossChest : Chest
{
	[SerializeField]
	private GameObject bossKey;

	public override void GiveItems()
	{
		bossKey = Instantiate(bossKey, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		StartCoroutine(Write("You have obtained a boss key!", bossKey));

		if (playerInventory.BOSSKEY < 1)
			playerInventory.BOSSKEY++;
	}
}