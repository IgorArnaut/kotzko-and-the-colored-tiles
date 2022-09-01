using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	public static SaveManager Instance;

	public Vector2 playerPos;
	public bool[] stepped;
	public bool[] open;
	public bool[] locked;

	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void Save()
	{
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

		stepped = GameObject.FindGameObjectsWithTag("GreenTile")
			.OrderBy(gt => gt.name)
			.Select(gt => gt.GetComponent<GreenTileAction>())
			.Select(gt => gt.stepped)
			.ToArray();

		open = GameObject.FindGameObjectsWithTag("Chest")
			.OrderBy(c => c.name)
			.Select(c => c.GetComponent<Chest>())
			.Select(c => c.open)
			.ToArray();

		locked = GameObject.FindGameObjectsWithTag("Gate")
			.OrderBy(g => g.name)
			.Select(g => g.GetComponent<Gate>())
			.Select(g => g.locked)
			.ToArray();
	}

	public void Load()
	{
		Transform player = GameObject.FindGameObjectWithTag("Player").transform;

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

		if (Instance != null)
		{
			player.position = playerPos;

			foreach (var gt in greenTiles.Zip(stepped, Tuple.Create))
				gt.Item1.stepped = gt.Item2;

			foreach (var c in chests.Zip(open, Tuple.Create))
				c.Item1.open = c.Item2;

			foreach (var g in gates.Zip(locked, Tuple.Create))
				g.Item1.locked = g.Item2;
		}
	}
}
