using UnityEngine;

public class Water : TileAction
{
	// Player
	[SerializeField]
	private Stats playerStats;
	public BoolValue inWater;
	private float temp;

	void Start()
	{
		temp = playerStats.SPEED;
	}

	override protected void DoEnterAction()
	{
		inWater.value = true;
		playerStats.SPEED *= 0.75f;
	}

	override protected void DoExitAction()
	{
		inWater.value = false;
		playerStats.SPEED = temp;
	}
}
