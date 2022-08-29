using System.Collections;
using UnityEngine;

public class GreenTileAction : TileAction
{
	private SpriteRenderer sr;

	private GameObject player;
	private GameObject clue;

	[SerializeField]
	private SceneManager2 manager;

	public bool stepped;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		clue = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
	}

	void Update()
	{
		if (stepped)
			sr.color = Color.HSVToRGB(0.0f, 0.0f, 0.8f);
	}

	private void LoadScene()
	{
		clue.SetActive(false);
		clue.GetComponent<Animator>().SetInteger("clue", 0);
		manager.Transition("Battle");
	}

	override protected void DoEnterAction()
	{
		if (!stepped)
		{
			stepped = true;

			clue.SetActive(true);
			clue.GetComponent<Animator>().SetInteger("clue", 3);
			player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			Invoke(nameof(LoadScene), 1.0f);
		}
	}

	override protected void DoExitAction()
	{
		return;
	}
}
