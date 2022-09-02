using System;
using System.Linq;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	// Instance
	public static SaveManager Manager;

	// Data
	[SerializeField]
	private Progress progress;

	void Awake()
	{
		Manager = this;
	}

	// Save data
	public void SaveData()
	{
		progress.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		progress.cameraPos = Camera.main.transform.position;
		progress.stepped = GameObject.FindGameObjectsWithTag("GreenTile")
			.OrderBy(gt => gt.name)
			.Select(gt => gt.GetComponent<GreenTileAction>())
			.Select(gt => gt.stepped)
			.ToArray();
		progress.open = GameObject.FindGameObjectsWithTag("Chest")
			.OrderBy(c => c.name)
			.Select(c => c.GetComponent<Chest>())
			.Select(c => c.open)
			.ToArray();
		progress.locked = GameObject.FindGameObjectsWithTag("Gate")
			.OrderBy(g => g.name)
			.Select(g => g.GetComponent<Gate>())
			.Select(g => g.locked)
			.ToArray();
		Debug.Log("Progress saved.");
	}

	// Load data
	public void LoadData()
	{
		Transform player = GameObject.FindGameObjectWithTag("Player").transform;
		Transform camera = Camera.main.transform;

		GreenTileAction[] greenTiles = GameObject.FindGameObjectsWithTag("GreenTile")
			.OrderBy(gt => gt.name)
			.Select(gt => gt.GetComponent<GreenTileAction>())
			.ToArray();

		Chest[] chests = GameObject.FindGameObjectsWithTag("Chest")
			.OrderBy(c => c.name)
			.Select(c => c.GetComponent<Chest>())
			.ToArray();

		Gate[] gates = GameObject.FindGameObjectsWithTag("Gate")
			.OrderBy(g => g.name)
			.Select(g => g.GetComponent<Gate>())
			.ToArray();

		player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

		if (!progress.IsNULL())
		{
			player.position = progress.playerPos;
			camera.position = camera.position;
			foreach (var gt in greenTiles.Zip(progress.stepped, Tuple.Create)) gt.Item1.stepped = gt.Item2;
			foreach (var c in chests.Zip(progress.open, Tuple.Create)) c.Item1.open = c.Item2;
			foreach (var g in gates.Zip(progress.locked, Tuple.Create)) g.Item1.locked = g.Item2;
			Debug.Log("Progress loaded.");
		}
	}
}
