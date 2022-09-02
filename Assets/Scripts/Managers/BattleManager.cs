using System.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
	// Components
	private AudioSource src;

	// Units
	private GameObject player;
	private GameObject enemy;

	// Victory & Defeat
	[SerializeField]
	private string[] defeat;
	[SerializeField]
	private string[] victory;
	private bool once;

	void Awake()
	{
		GetComponents();
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	void Update()
	{
		Victory();
		Defeat();
	}

	// Get Components
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Defeat
	private void Defeat()
	{
		if (player == null && !once)
		{
			once = true;
			MusicManager.Manager.Stop();
			MusicManager.Manager.PlayOneshot(MusicManager.Manager.clips[0]);
			DialogManager.Manager.WriteLines2(defeat);
			SceneManager2.Manager.Transition("GameOver");
		}
	}

	// Victory
	private void Victory() {
		if (enemy == null && !once) {
			once = true;
			MusicManager.Manager.Stop();
			MusicManager.Manager.PlayOneshot(MusicManager.Manager.clips[1]);
			DialogManager.Manager.WriteLines2(victory);
			SceneManager2.Manager.Transition("Dungeon");
		}
	}
}
