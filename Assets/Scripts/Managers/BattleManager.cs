using UnityEngine;

public class BattleManager : GameManager
{
	// Jedinice
	private GameObject enemy;

	// Poruke
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

	// Radi nesto
	private void Victory()
	{
		if (enemy == null && !once)
		{
			once = true;
			StartCoroutine(DoSomething(MusicManager.Manager.clips[1], victory, sceneName));
		}
	}
}
