using System.Collections;
using UnityEngine;

public class OrangeTileAction : TileAction
{
	// Player
	[SerializeField]
	private Stats playerStats;
	public BoolValue orange;
	private float temp;

	void Start()
	{
		temp = playerStats.SPEED;
	}

	// Orange
	private IEnumerator Orange()
	{
		orange.value = true;
		playerStats.SPEED /= 2;
		yield return new WaitForSeconds(60.0f);
		playerStats.SPEED = temp;
		orange.value = false;
	}

	override protected void DoEnterAction()
	{
		StartCoroutine(nameof(Orange));
	}

	override protected void DoExitAction()
	{
		return;
	}
}
