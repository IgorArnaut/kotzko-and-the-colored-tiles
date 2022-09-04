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

	override protected void Start()
	{
		base.Start();
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	override protected void Update()
	{
		base.Update();
		Victory();
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
