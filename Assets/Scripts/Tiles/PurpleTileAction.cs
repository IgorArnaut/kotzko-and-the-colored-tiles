using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleTileAction : TileAction
{
	[SerializeField]
	private Stats playerStats;
	public BoolValue lemon;

	private float temp;

	void Start()
	{
		temp = playerStats.speed;
	}

	override protected void DoEnterAction()
	{
		lemon.value = true;
		playerStats.speed *= 2;
	}

	override protected void DoExitAction()
	{
		lemon.value = false;
		playerStats.speed = temp;
	}
}
