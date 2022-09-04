using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Jedinice
	protected GameObject player;

	// Pokretanje igre
	[SerializeField]
	protected BoolValue started;

	// Objekti
	[SerializeField]
	private Progress progress;
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private Inventory inventory;

	// Poruke
	[SerializeField]
	protected string[] defeat;

	virtual protected void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	virtual protected void OnApplicationQuit()
	{
		Debug.Log("Quitting game...");
		playerStats.ResetStats(100, 100, 10, 10, 5.0f);
		inventory.ResetInventory();
		progress.ResetProgress();
		started.value = false;
	}

	// Radi nesto
	protected IEnumerator DoSomething(AudioClip clip, string[] messages, string sceneName)
	{
		yield return new WaitForSeconds(0.5f);
		MusicManager.Manager.Stop();
		MusicManager.Manager.PlayOneshot(clip);
		DialogManager.Manager.SetActive(true, false, false);
		DialogManager.Manager.WriteLines2(messages);
		yield return new WaitForSeconds(2.0f);
		SceneManager2.Manager.Transition(sceneName);
	}
}