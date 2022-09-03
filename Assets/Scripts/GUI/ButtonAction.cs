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

	// Resets data & progress
	private void ResetData()
	{
		progress.ResetProgress();
		playerStats.ResetStats(100, 100, 10, 10, 5.0f);
		playerInventory.ResetInventory();
		Debug.Log("Progress reset.");
	}

	// Plays Game
	public void PlayGame(string sceneName)
	{
		Debug.Log("Playing game...");
		ResetData();
		src.PlayOneShot(clip);
		SceneManager2.Manager.Transition(sceneName);
	}

	// Quits Game
	public void QuitGame()
	{
		Debug.Log("Quitting game...");
		Application.Quit();
	}
}
