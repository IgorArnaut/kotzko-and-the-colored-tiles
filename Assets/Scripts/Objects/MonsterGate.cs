using UnityEngine;

public class MonsterGate : Gate
{
	// Zelena polja
	[SerializeField] 
	private GreenTileAction[] greenTiles;

	// Otkljucava kapiju
	public override void Unlock()
	{
		if (locked && greenTiles.Length != 0)
		{
			foreach (GreenTileAction tile in greenTiles) if (tile.stepped == false) return;
			locked = false;
			src.PlayOneShot(clips[0]);
		}
	}
}
