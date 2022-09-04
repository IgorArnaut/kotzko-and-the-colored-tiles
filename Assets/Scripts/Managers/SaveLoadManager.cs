using System.Linq;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
	// Instanca
	public static SaveLoadManager Manager;

	// Podaci
	[SerializeField]
	private Progress progress;

	void Awake()
	{
		Manager = this;
		LoadData();
	}

	// Cuva podatke
	public void SaveData()
	{
		progress.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		progress.cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
		progress.stepped = GameObject.FindGameObjectsWithTag("GreenTile")
			.OrderBy(gt => Vector3.Distance(gt.transform.position, Vector3.zero))
			.Select(gt => gt.GetComponent<GreenTileAction>())
			.Select(gt => gt.stepped)
			.ToArray();
		progress.open = GameObject.FindGameObjectsWithTag("Chest")
			.OrderBy(c => Vector3.Distance(c.transform.position, Vector3.zero))
			.Select(c => c.GetComponent<Chest>())
			.Select(c => c.open)
			.ToArray();
		progress.locked = GameObject.FindGameObjectsWithTag("Gate")
			.OrderBy(g => Vector3.Distance(g.transform.position, Vector3.zero))
			.Select(g => g.GetComponent<Gate>())
			.Select(g => g.locked)
			.ToArray();
		Debug.Log("Progress saved.");
	}

	// Uvozi podatke
	public void LoadData()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		GameObject[] greenTiles = GameObject.FindGameObjectsWithTag("GreenTile")
			.OrderBy(gt => Vector3.Distance(gt.transform.position, Vector3.zero))
			.ToArray();
		GameObject[] chests = GameObject.FindGameObjectsWithTag("Chest")
			.OrderBy(c => Vector3.Distance(c.transform.position, Vector3.zero))
			.ToArray();
		GameObject[] gates = GameObject.FindGameObjectsWithTag("Gate")
			.OrderBy(g => Vector3.Distance(g.transform.position, Vector3.zero))
			.ToArray();

		player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

		if (!progress.IsNULL())
		{
			player.transform.position = progress.playerPos;
			camera.transform.position = progress.cameraPos;
			for (int i = 0; i < greenTiles.Length; i++) greenTiles[i].GetComponent<GreenTileAction>().stepped = progress.stepped[i];
			for (int i = 0; i < chests.Length; i++) chests[i].GetComponent<Chest>().open = progress.open[i];
			for (int i = 0; i < gates.Length; i++) gates[i].GetComponent<Gate>().locked = progress.locked[i];
			Debug.Log("Progress loaded.");
		}
	}
}
