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
		SceneManager2.Manager.Transition("Battle");
	}

	override protected void DoEnterAction()
	{
		if (!stepped)
		{
			stepped = true;

			clue.SetActive(true);
			clue.GetComponent<Animator>().SetTrigger("exclamation");
			player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

			SaveManager.Instance.Save();
			Invoke(nameof(LoadScene), 1.0f);
		}
	}

	override protected void DoExitAction()
	{
		return;
	}
}
