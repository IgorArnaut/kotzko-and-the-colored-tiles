using UnityEngine;

public class HeartChest : Chest
{
	// Srce
	[SerializeField]
	private GameObject heart;

	// Daje srca
	override protected void GiveItems()
	{
		base.GiveItems();
		int hearts = Random.Range(2, 5);
		heart = Instantiate(heart, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		playerInventory.HEARTS += hearts;
		StartCoroutine(Write("You have obtained " + hearts + " hearts!", heart));
	}
}