using UnityEngine;

public class OrangeTileAction : TileAction
{
	[SerializeField]
	private Stats playerStats;

	public BoolValue orange;

	private float temp;

	void Start()
	{
		temp = playerStats.speed;
	}

	override protected void DoEnterAction()
	{
		orange.value = true;
		playerStats.speed /= 2;
	}

	override protected void DoExitAction()
	{
		orange.value = false;
		playerStats.speed = temp;
	}
}
