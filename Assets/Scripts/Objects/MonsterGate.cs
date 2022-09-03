using UnityEngine;

public class MonsterGate : Gate
{
	// Green tiles
	[SerializeField] 
	private Portal[] greenTiles;

	// Unlocks gate
	public override void Unlock()
	{
		if (locked && greenTiles.Length != 0)
		{
			foreach (Portal tile in greenTiles) if (tile.stepped == false) return;
			locked = false;
			src.PlayOneShot(clips[0]);
		}
	}
}
