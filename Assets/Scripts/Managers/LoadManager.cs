using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
	void Start()
	{
		Load();
	}

	private void Load()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		GameObject[] greenTiles = GameObject.FindGameObjectsWithTag("GreenTile")
			.OrderBy(gt => gt.name)
			.ToArray();
		GameObject[] chests = GameObject.FindGameObjectsWithTag("Chest")
			.OrderBy(c => c.name)
			.ToArray();
		GameObject[] gates = GameObject.FindGameObjectsWithTag("Gate")
			.OrderBy(g => g.name)
			.ToArray();

		player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

		if (SaveManager.Instance != null)
		{
			player.transform.position = SaveManager.Instance.playerPos;

			Debug.Log("Stepped?");
			foreach (var stepped in greenTiles.Zip(SaveManager.Instance.greenTiles, Tuple.Create))
			{
				stepped.Item1.GetComponent<GreenTileAction>().stepped = stepped.Item2;
				Debug.Log("stepped" + stepped.Item1.GetComponent<GreenTileAction>().stepped);
			}

			Debug.Log("Open?");
			foreach (var open in chests.Zip(SaveManager.Instance.chests, Tuple.Create)) {
				open.Item1.GetComponent<Chest>().open = open.Item2;
				Debug.Log("open " + open.Item1.GetComponent<Chest>().open);
			}

			Debug.Log("Locked?");
			foreach (var locked in gates.Zip(SaveManager.Instance.gates, Tuple.Create))
			{
				locked.Item1.GetComponent<Gate>().locked = locked.Item2;
				Debug.Log("locked: " + locked.Item1.GetComponent<Gate>().locked);
			}
		}
	}
}
