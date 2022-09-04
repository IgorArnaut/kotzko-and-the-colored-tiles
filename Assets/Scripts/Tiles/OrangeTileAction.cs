using System.Collections;
using UnityEngine;

public class OrangeTileAction : TileAction
{
	// Igrac
	[SerializeField]
	private Stats playerStats;
	public BoolValue orange;
	private float temp;

	void Start()
	{
		temp = playerStats.SPEED;
	}

	// Boji igraca u narandzasto i smanjuje mu brzinu
	private IEnumerator Orange()
	{
		orange.value = true;
		playerStats.SPEED /= 2;
		yield return new WaitForSeconds(30.0f);
		playerStats.SPEED = temp;
		orange.value = false;
	}

	// Radi nesto u koliziji
	override protected void DoEnterAction()
	{
		StartCoroutine(nameof(Orange));
	}

	// Radi nesto van kolizije
	override protected void DoExitAction()
	{
		return;
	}
}
