using UnityEngine;

[CreateAssetMenu]
public class Progress : ScriptableObject
{
	public Vector2 playerPos;
	public Vector2 cameraPos;
	public bool[] stepped;
	public bool[] open;
	public bool[] locked;

	// Resets progress
	public void ResetProgress()
	{
		this.playerPos = Vector2.zero;
		this.cameraPos = Vector2.zero;
		this.stepped = null;
		this.open = null;
		this.locked = null;
	}

	// Checks if progress is null
	public bool IsNULL()
	{
		return Vector2.Distance(this.playerPos, Vector2.zero) != 0.0f && Vector2.Distance(this.cameraPos, Vector2.zero) != 0.0f && this.stepped == null && this.open == null && this.locked == null;
	}
}