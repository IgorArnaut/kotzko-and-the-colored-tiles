using System.Collections;
using UnityEngine;

public class YellowTileAction : TileAction
{
	// Igrac
	[SerializeField]
	private Stats playerStats;
	public BoolValue electric;

	// Povredjuje igraca
	private IEnumerator Damage()
	{
		while (true)
		{
			playerStats.TakeDamge(5);
			yield return new WaitForSeconds(0.2f);
		}
	}

	// Radi nesto u koliziji
	override protected void DoEnterAction()
	{
		electric.value = true;
		StartCoroutine(nameof(Damage));
	}

	// Radi nesto van kolizije
	override protected void DoExitAction()
	{
		electric.value = false;
		StopCoroutine(nameof(Damage));
	}
}
