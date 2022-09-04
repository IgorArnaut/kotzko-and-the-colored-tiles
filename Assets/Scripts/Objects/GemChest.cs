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
		gem = Instantiate(gem, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		int gems = Random.Range(1, 6);
		playerInventory.GEMS += gems;

		switch (gems)
		{
			case 0: StartCoroutine(Write("You have obtained no gems!", gem)); break;
			case 1: StartCoroutine(Write("You have obtained a gem!", gem)); break;
			default: StartCoroutine(Write("You have obtained " + gems + " gems!", gem)); break;
		}

	}
}