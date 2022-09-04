using UnityEngine;

public class ButtonAction : MonoBehaviour
{
	// Komponente
	private AudioSource src;

	// Pokretanje igre
	[SerializeField]
	private AudioClip clip;

	void Awake()
	{
		GetComponents();
	}

	// Uzima komponente
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Pokrece igru
	public void PlayGame(string sceneName)
	{
		Debug.Log("Playing game...");
		ResetManager.Manager.ResetData();
		src.PlayOneShot(clip);
		SceneManager2.Manager.Transition(sceneName);
	}

	// Prekida igru
	public void QuitGame()
	{
		Debug.Log("Quitting game...");
		ResetManager.Manager.ResetData();
		Application.Quit();
	}
}
