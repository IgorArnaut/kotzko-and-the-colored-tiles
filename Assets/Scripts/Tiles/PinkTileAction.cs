using System.Collections;
using UnityEngine;

public class PinkTileAction : TileAction
{
	[SerializeField]
	private Stats playerStats;

	public BoolValue heal;

	private IEnumerator Heal()
	{
		while (playerStats.HP < playerStats.MAXHP)
		{
			yield return new WaitForSeconds(0.2f);
			playerStats.Heal(5);
		}
	}

	override protected void DoEnterAction()
	{
		heal.value = true;
		StartCoroutine(nameof(Heal));
	}

	override protected void DoExitAction()
	{
		heal.value = false;
		StopCoroutine(nameof(Heal));
	}
}
