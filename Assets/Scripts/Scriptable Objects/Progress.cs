using UnityEngine;

[CreateAssetMenu]
public class Progress : ScriptableObject
{
	public Vector2 playerPos;
	public Vector2 cameraPos;
	public bool[] stepped;
	public bool[] open;
	public bool[] locked;

	// Reset progress
	public void Reset()
	{
		playerPos = Vector2.zero;
		cameraPos = Vector2.zero;
		stepped = null;
		open = null;
		locked = null;
	}

	// Is null?
	public bool IsNULL()
	{
		return Vector2.Distance(playerPos, Vector2.zero) != 0.0f && Vector2.Distance(cameraPos, Vector2.zero) != 0.0f && stepped == null && open == null && locked == null;
	}
}