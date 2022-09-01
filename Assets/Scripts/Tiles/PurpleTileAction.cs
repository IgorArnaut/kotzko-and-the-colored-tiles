using System.Collections;
using UnityEngine;

public class PurpleTileAction : TileAction
{
	[SerializeField]
	private Stats playerStats;

	public BoolValue lemon;

	private float temp;

	void Start()
	{
		temp = playerStats.SPEED;
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

	private IEnumerator Lemon()
	{
		lemon.value = true;
		yield return new WaitForSeconds(60.0f);
		lemon.value = false;
	}
}
