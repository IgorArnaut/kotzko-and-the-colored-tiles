using UnityEngine;

public class GreenTileAction : TileAction
{
	// Komponente
	private SpriteRenderer sr;

	// Igrac
	private GameObject player;
	private GameObject clue;

	// Stajanje
	[SerializeField]
	private AudioClip clip;
	public bool stepped;

	void Awake()
	{
		GetComponents();
	}

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		clue = player.transform.GetChild(0).gameObject;
	}

	void Update()
	{
		DimTile();
	}

	// Uzima komponente
	private void GetComponents()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	// Potamnjuje polje
	private void DimTile()
	{
		if (stepped) sr.color = Color.HSVToRGB(0.0f, 0.0f, 0.8f);
	}

	// Pokrece scenu
	private void LoadScene()
	{
		clue.SetActive(false);
		MusicManager.Manager.Stop();
		MusicManager.Manager.PlayOneshot(clip);
		SceneManager2.Manager.Transition("Battle");
	}

	// Radi nesto u koliziji
	override protected void DoEnterAction()
	{
		if (!stepped)
		{
			stepped = true;
			clue.SetActive(true);
			clue.GetComponent<Animator>().SetTrigger("exclamation");
			player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			SaveLoadManager.Manager.SaveData();
			Invoke(nameof(LoadScene), 1.0f);
		}
	}

	// Radi nesto van kolizije
	override protected void DoExitAction()
	{
		return;
	}
}
