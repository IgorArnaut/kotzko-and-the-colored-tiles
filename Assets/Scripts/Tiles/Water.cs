using UnityEngine;

public class Water : TileAction
{
	// Igrac
	[SerializeField]
	private Stats playerStats;
	public BoolValue inWater;
	private float temp;

	void Start()
	{
		temp = playerStats.SPEED;
	}

	// Radi nesto u koliziji
	override protected void DoEnterAction()
	{
		inWater.value = true;
		playerStats.SPEED *= 0.75f;
	}

	// Radi nesto van kolizije
	override protected void DoExitAction()
	{
		inWater.value = false;
		playerStats.SPEED = temp;
	}
}
