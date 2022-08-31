using UnityEngine;

public class Water : TileAction
{
	[SerializeField]
	private Stats playerStats;

	public BoolValue inWater;

	private float temp;

	void Start()
	{
		temp = playerStats.speed;
	}

	override protected void DoEnterAction()
	{
		inWater.value = true;

		playerStats.speed *= 0.75f;
	}

	override protected void DoExitAction()
	{
		inWater.value = false;

		playerStats.speed = temp;
	}
}
