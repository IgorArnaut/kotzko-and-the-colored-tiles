using UnityEngine;

public class ButtonAction : MonoBehaviour
{
	// Komponente
	private AudioSource src;

	// Pokretanje igre
	[SerializeField]
	private AudioClip clip;

	// Resetovanje podataka
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private Inventory playerInventory;
	[SerializeField]
	private Progress progress;
	[SerializeField]
	private BoolValue started;

	void Awake()
	{
		GetComponents();
	}

	// Uzima komponente
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Resetuje podatke
	private void ResetData()
	{
		playerStats.ResetStats(100, 100, 10, 10, 5.0f);
		playerInventory.ResetInventory();
		progress.ResetProgress();
		started.value = false;
		Debug.Log("Progress reset.");
	}

	// Pokrece igru
	public void PlayGame(string sceneName)
	{
		Debug.Log("Playing game...");
		ResetData();
		src.PlayOneShot(clip);
		SceneManager2.Manager.Transition(sceneName);
	}

	// Prekida igru
	public void QuitGame()
	{
		Debug.Log("Quitting game...");
		ResetData();
		Application.Quit();
	}
}
