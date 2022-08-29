using System.Collections.Generic;
using UnityEngine;

public class MonsterGate : Gate
{
	[SerializeField] 
	private List<GreenTileAction> greenTiles;

	public override void Unlock()
	{
		if (locked && greenTiles.Count != 0)
		{
			foreach (GreenTileAction tile in greenTiles)
			{
				if (tile.stepped == false)
					return;
			}

			locked = false;
		}
	}
}
