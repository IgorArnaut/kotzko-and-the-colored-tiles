using System.Collections;
using UnityEngine;

public class OrangeTileAction : TileAction
{
	[SerializeField]
	private Stats playerStats;

	public BoolValue orange;

	private float temp;

	void Start()
	{
		temp = playerStats.SPEED;
	}

	override protected void DoEnterAction()
	{
		StartCoroutine(nameof(Orange));
	}

	override protected void DoExitAction()
	{
		return;
	}

	private IEnumerator Orange()
	{
		orange.value = true;
		playerStats.SPEED /= 2;
		yield return new WaitForSeconds(60.0f);
		playerStats.SPEED = temp;
		orange.value = false;
	}
}
