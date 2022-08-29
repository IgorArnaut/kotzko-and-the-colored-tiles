public class KeyChest : Chest
{
	public override void GiveItems() 
	{
		playerInventory.keys += 1;
	}
}