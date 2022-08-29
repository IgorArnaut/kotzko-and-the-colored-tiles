using UnityEngine;

public class HeartChest : Chest
{
	[SerializeField] private int hearts;

	public override void GiveItems()
	{
		playerInventory.hearts += hearts;
		hearts = 0;
	}
}