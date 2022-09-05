using UnityEngine;

public class GemChest : Chest
{
	// Dragulj
	[SerializeField]
	private GameObject gem;

	// Daje dragulje
	override protected void GiveItems()
	{
		base.GiveItems();
		int gems = Random.Range(2, 5);
		gem = Instantiate(gem, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		playerInventory.GEMS += gems;
		StartCoroutine(Write("You have obtained " + gems + " gems!", gem));
	}
}