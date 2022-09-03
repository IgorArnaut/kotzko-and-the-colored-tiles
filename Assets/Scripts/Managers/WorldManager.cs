public class WorldManager : GameManager
{
	private bool once;

	void Update()
	{
		Defeat();
	}

	// Does something on defeat
	private void Defeat()
	{
		if (player == null && !once)
		{
			StartCoroutine(DoSomething(MusicManager.Manager.clips[0], defeat, "GameOver"));
			once = true;
		}
	}
}
