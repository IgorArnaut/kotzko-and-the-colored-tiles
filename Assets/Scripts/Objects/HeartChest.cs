using UnityEngine;

public class HeartChest : Chest
{
	[SerializeField]
	private GameObject heart;

	public override void GiveItems()
	{
		heart = Instantiate(heart, player.transform.position + Vector3.up * 2.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		int hearts = Random.Range(0, 3);

		switch (hearts)
		{
			case 0:
				StartCoroutine(Write("You have obtained no hearts!", heart));
				break;
			case 1:
				StartCoroutine(Write("You have obtained a heart!", heart));
				break;
			default:
				StartCoroutine(Write("You have obtained " + hearts + " hearts!", heart));
				break;
		}

		playerInventory.HEARTS += hearts;
	}
}