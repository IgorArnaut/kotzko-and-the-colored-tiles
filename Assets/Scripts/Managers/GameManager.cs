using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Units
	protected GameObject player;

	// ScriptableObjects
	[SerializeField]
	private Progress progress;
	[SerializeField]
	private Stats playerStats;
	[SerializeField]
	private Inventory inventory;

	// Messages
	[SerializeField]
	protected string[] defeat;

	virtual protected void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnApplicationQuit()
	{
		progress.ResetProgress();
		playerStats.ResetStats(100, 100, 10, 10, 5.0f);
		inventory.ResetInventory();
	}

	// Does something
	protected IEnumerator DoSomething(AudioClip clip, string[] messages, string sceneName)
	{
		yield return new WaitForSeconds(2.0f);
		MusicManager.Manager.Stop();
		MusicManager.Manager.PlayOneshot(clip);
		DialogManager.Manager.SetActive(true, false, false);
		DialogManager.Manager.WriteLines2(messages);
		
		if (DialogManager.Manager.finished)
			SceneManager2.Manager.Transition(sceneName);
	}
}