using UnityEngine;

[CreateAssetMenu]
public class Progress : ScriptableObject
{
	// Vrednosti
	public Vector2 playerPos;
	public Vector2 cameraPos;
	public bool[] stepped;
	public bool[] open;
	public bool[] locked;

	// Resetuje progres
	public void ResetProgress()
	{
		this.playerPos = Vector2.zero;
		this.cameraPos = Vector2.zero;
		this.stepped = null;
		this.open = null;
		this.locked = null;
	}

	// Proverava da li je progres 0
	public bool IsNULL()
	{
		return Vector2.Distance(this.playerPos, Vector2.zero) == 0.0f && Vector2.Distance(this.cameraPos, Vector2.zero) == 0.0f && this.stepped.Length == 0 && this.open.Length == 0 && this.locked.Length == 0;
	}
}