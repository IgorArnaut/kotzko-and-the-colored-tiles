using System.Collections;
using UnityEngine;

public class YellowTileAction : TileAction
{
	// Player
	[SerializeField]
	private Stats playerStats;
	public BoolValue electric;

	// Damage
	private IEnumerator Damage()
	{
		while (playerStats.HP >= 0)
		{
			yield return new WaitForSeconds(0.2f);
			playerStats.TakeDamge(5);
		}
	}

	override protected void DoEnterAction()
	{
		electric.value = true;
		StartCoroutine(nameof(Damage));
	}

	override protected void DoExitAction()
	{
		electric.value = false;
		StopCoroutine(nameof(Damage));
	}
}
