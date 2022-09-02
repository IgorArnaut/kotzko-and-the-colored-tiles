using System.Collections;
using UnityEngine;

public class PurpleTileAction : TileAction
{
	// Player
	[SerializeField]
	private Stats playerStats;
	public BoolValue lemon;
	private float temp;

	void Start()
	{
		temp = playerStats.SPEED;
	}

	// Lemon
	private IEnumerator Lemon()
	{
		lemon.value = true;
		yield return new WaitForSeconds(60.0f);
		lemon.value = false;
	}

	override protected void DoEnterAction()
	{
		StartCoroutine(nameof(Lemon));
		playerStats.SPEED *= 2;
	}

	override protected void DoExitAction()
	{
		playerStats.SPEED = temp;
	}

}
