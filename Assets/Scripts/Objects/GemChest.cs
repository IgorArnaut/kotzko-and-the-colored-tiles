using UnityEngine;

public class GemChest : Chest
{
	// Gem
	[SerializeField]
	private GameObject gem;

	// Gives gems
	public override void GiveItems()
	{
		gem = Instantiate(gem, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		int gems = Random.Range(1, 6);
		playerInventory.GEMS += gems;

		switch (gems)
		{
			case 0: StartCoroutine(Write("You have obtained no gems!", gem)); break;
			case 1: StartCoroutine(Write("You have obtained a gem!", gem)); break;
			default: StartCoroutine(Write("You have obtained " + gems + " gems!", gem)); break;
		}

		PlayerItem();
	}
}