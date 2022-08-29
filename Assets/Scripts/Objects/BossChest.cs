public class BossChest : Chest
{
	public override void GiveItems()
	{
		if (playerInventory.bossKey < 1)
			playerInventory.bossKey += 1;
	}
}