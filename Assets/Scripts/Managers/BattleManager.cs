using UnityEngine;

public class BattleManager : GameManager
{
	// Units
	private GameObject enemy;

	// Messages
	[SerializeField]
	private string[] victory;
	[SerializeField]
	private string sceneName;
	private bool once;

	override protected void Start()
	{
		base.Start();
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	void Update()
	{
		Defeat();
		Victory();
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

	// Does something on victory
	private void Victory()
	{
		if (enemy == null && !once)
		{
			StartCoroutine(DoSomething(MusicManager.Manager.clips[1], victory, sceneName));
			once = true;
		}
	}
}
