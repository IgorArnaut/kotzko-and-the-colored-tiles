using UnityEngine;

public class MonsterGate : Gate
{
	[SerializeField] 
	private GreenTileAction[] greenTiles;

	public override void Unlock()
	{
		if (locked && greenTiles.Length != 0)
		{
			foreach (GreenTileAction tile in greenTiles)
			{
				if (tile.stepped == false)
					return;
			}

			GetComponent<AudioSource>().PlayOneShot(clips[0]);
			locked = false;
		}
	}
}
