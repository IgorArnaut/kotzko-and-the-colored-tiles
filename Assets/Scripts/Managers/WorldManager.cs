using UnityEngine;
using UnityEngine.Playables;

public class WorldManager : GameManager
{
	// Komponente
	private PlayableDirector director;

	// Pokretanje igre
	[SerializeField]
	private BoolValue started;

	void Awake()
	{
		GetComponents();
	}

	override protected void Start()
	{
		base.Start();
		if (!started.value) director.Play();
	}

	override protected void Update()
	{
		base.Update();
	}

	// Uzima komponente
	private void GetComponents()
	{
		director = GetComponent<PlayableDirector>();
	}


	// Podesava vrednost started
	public void SetStarted()
	{
		this.started.value = true;
	}
}
