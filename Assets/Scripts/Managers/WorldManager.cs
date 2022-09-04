using UnityEngine.Playables;

public class WorldManager : GameManager
{
	// Komponente
	private PlayableDirector director;
	private bool once;

	void Awake()
	{
		GetComponents();
	}

	override protected void Start()
	{
		base.Start();
		if (!started.value) director.Play();
	}

	void Update()
	{
		Defeat();
	}

	// Uzima komponente
	private void GetComponents()
	{
		director = GetComponent<PlayableDirector>();
	}

	// Radi nesto
	private void Defeat()
	{
		if (player == null && !once)
		{
			once = true;
			started.value = false;
			StartCoroutine(DoSomething(MusicManager.Manager.clips[0], defeat, "GameOver"));
		}
	}

	// Podesava vrednost started
	public void SetStarted()
	{
		this.started.value = true;
	}
}
