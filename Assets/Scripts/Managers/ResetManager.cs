using UnityEngine;

public class ResetManager : MonoBehaviour
{
	// Instanca
	public static ResetManager Manager;

	// Podaci
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private Inventory playerInventory;
	[SerializeField]
	private Progress progress;
	[SerializeField]
	private BoolValue[] values;

	void Awake()
	{
		Manager = this;
	} 

	void OnApplicationQuit()
	{
		ResetData();
	}

	// Resetuje sve podatke
	public void ResetData()
	{
		playerStats.ResetStats(100, 100, 10, 10, 5.0f);
		playerInventory.ResetInventory();
		progress.ResetProgress();
		foreach (BoolValue bv in values) bv.ResetValue();
	}
}