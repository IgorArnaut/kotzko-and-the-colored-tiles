using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject
{
	// Vrednost
	public bool value;

	// Resetuje vrednost
	public void ResetValue()
	{
		this.value = false;
	}
}
