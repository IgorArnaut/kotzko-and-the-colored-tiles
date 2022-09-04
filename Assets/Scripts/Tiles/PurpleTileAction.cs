using System.Collections;
using UnityEngine;

public class PurpleTileAction : TileAction
{
	// Igrac
	[SerializeField]
	private Stats playerStats;
	public BoolValue purple;
	private float temp;

	void Start()
	{
		temp = playerStats.SPEED;
	}

	// Boji igraca u ljubicasto
	private IEnumerator Purple()
	{
		purple.value = true;
		yield return new WaitForSeconds(30.0f);
		purple.value = false;
	}

	// Radi nesto u koliziji
	override protected void DoEnterAction()
	{
		StartCoroutine(nameof(Purple));
		playerStats.SPEED *= 2;
	}

	// Radi nesto van kolizije
	override protected void DoExitAction()
	{
		playerStats.SPEED = temp;
	}

}
