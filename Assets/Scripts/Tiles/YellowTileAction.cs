using System.Collections;
using UnityEngine;

public class YellowTileAction : TileAction
{
	[SerializeField]
	private Stats playerStats;
	public BoolValue electric;

	private IEnumerator Hurt()
	{
		while (playerStats.HP >= 0)
		{
			yield return new WaitForSeconds(0.1f);
			playerStats.TakeDamge(5);
		}
	}

	override protected void DoEnterAction()
	{
		electric.value = true;
		StartCoroutine(nameof(Hurt));
	}

	override protected void DoExitAction()
	{
		electric.value = false;
		StopCoroutine(nameof(Hurt));
	}
}
