using UnityEngine;

public class ButtonAction : MonoBehaviour
{
	// Components
	private AudioSource src;

	// Play Game
	[SerializeField]
	private AudioClip clip;

	// Reset data
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private Inventory playerInventory;
	[SerializeField]
	private Progress progress;

	void Awake()
	{
		GetComponents();
	}

	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Reset data
	private void ResetData()
	{
		progress.Reset();
		Debug.Log("Progress reset.");

		playerStats.MAXHP = 100;
		playerStats.HP = 100;
		playerStats.ATK = 10;
		playerStats.DEF = 10;
		playerStats.SPEED = 5.0f;

		playerInventory.GEMS = 0;
		playerInventory.HEARTS = 0;
		playerInventory.KEYS = 0;
		playerInventory.BOSSKEY = 0;
	}

	// Play Game
	public void PlayGame(string sceneName)
	{
		Debug.Log("Playing game...");
		ResetData();
		src.PlayOneShot(clip);
		SceneManager2.Manager.Transition(sceneName);
	}

	// Quit Game
	public void QuitGame()
	{
		Debug.Log("Quitting game...");
		Application.Quit();
	}
}
