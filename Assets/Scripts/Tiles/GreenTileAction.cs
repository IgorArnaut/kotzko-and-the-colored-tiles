using System;
using System.Linq;
using UnityEngine;

public class GreenTileAction : TileAction
{
	private SpriteRenderer sr;

	private GameObject player;
	private GameObject clue;

	public bool stepped;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		clue = player.transform.GetChild(0).gameObject;
	}

	void Update()
	{
		DimTile();
	}

	private void DimTile()
	{
		if (stepped)
			sr.color = Color.HSVToRGB(0.0f, 0.0f, 0.8f);
	}

	private void LoadScene()
	{
		clue.SetActive(false);
		clue.GetComponent<Animator>().SetInteger("clue", 0);
		SceneManager2.sManager2.Transition("Battle");
	}

	private void Save()
	{
		SaveManager.Instance.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

		SaveManager.Instance.greenTiles = GameObject.FindGameObjectsWithTag("GreenTile")
			.OrderBy(gt => gt.name)
			.Select(gt => gt.GetComponent<GreenTileAction>().stepped)
			.ToArray();
		SaveManager.Instance.chests = GameObject.FindGameObjectsWithTag("Chest")
			.OrderBy(c => c.name)
			.Select(c => c.GetComponent<Chest>().open)
			.ToArray();
		SaveManager.Instance.gates = GameObject.FindGameObjectsWithTag("Gate")
			.OrderBy(g => g.name)
			.Select(g => g.GetComponent<Gate>().locked)
			.ToArray();

		Debug.Log("Stepped?");
		foreach (bool stepped in SaveManager.Instance.greenTiles)
			Debug.Log("stepped" + stepped);

		Debug.Log("Open?");
		foreach (bool open in SaveManager.Instance.chests)
			Debug.Log("open " + open);

		Debug.Log("Locked?");
		foreach (bool locked in SaveManager.Instance.gates)
			Debug.Log("locked: " + locked);
	}

	override protected void DoEnterAction()
	{
		if (!stepped)
		{
			stepped = true;

			clue.SetActive(true);
			clue.GetComponent<Animator>().SetInteger("clue", 3);
			player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

			Save();
			Invoke(nameof(LoadScene), 1.0f);
		}
	}

	override protected void DoExitAction()
	{
		return;
	}
}
