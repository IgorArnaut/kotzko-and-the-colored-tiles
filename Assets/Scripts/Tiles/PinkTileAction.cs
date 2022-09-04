using System.Collections;
using UnityEngine;

public class PinkTileAction : TileAction
{
	// Igrac
	[SerializeField]
	private Stats playerStats;
	public BoolValue heal;

	// Leci igraca i boji u roze
	private IEnumerator Heal()
	{
		while (true)
		{
			playerStats.Heal(5);
			yield return new WaitForSeconds(0.2f);
		}
	}

	// Radi nesto u koliziji
	override protected void DoEnterAction()
	{
		heal.value = true;
		StartCoroutine(nameof(Heal));
	}

	// Radi nesto van kolizije
	override protected void DoExitAction()
	{
		heal.value = false;
		StopCoroutine(nameof(Heal));
	}
}
