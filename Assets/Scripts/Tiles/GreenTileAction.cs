using UnityEngine;

public class GreenTileAction : TileAction
{
	// Components
	private SpriteRenderer sr;

	// Player
	private GameObject player;
	private GameObject clue;

	// Transition
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

	// Gets Components
	private void GetComponents()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	// Dims tile
	private void DimTile()
	{
		if (stepped) sr.color = Color.HSVToRGB(0.0f, 0.0f, 0.8f);
	}

	// Loads a Scene
	private void LoadScene()
	{
		clue.SetActive(false);
		MusicManager.Manager.Stop();
		MusicManager.Manager.PlayOneshot(clip);
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
			SaveLoadManager.Manager.SaveData();
			Invoke(nameof(LoadScene), 1.0f);
		}
	}

	override protected void DoExitAction()
	{
		return;
	}
}
