using UnityEngine;

public class GemChest : Chest
{
	[SerializeField] private int gems;

	public override void GiveItems()
	{
		playerInventory.gems += gems;
		gems = 0;
	}
}