using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Jedinice
	protected GameObject player;

	// Poruke
	[SerializeField]
	protected string[] defeat;
	protected bool once;

	virtual protected void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	virtual protected void Update()
	{
		Defeat();
	}

	virtual protected void OnApplicationQuit()
	{
		Debug.Log("Quitting game...");
	}

	// Radi nesto
	private void Defeat()
	{
		if (player == null && !once)
		{
			once = true;
			ResetManager.Manager.ResetData();
			StartCoroutine(DoSomething(MusicManager.Manager.clips[0], defeat, "GameOver"));
		}
	}

	// Radi nesto
	protected IEnumerator DoSomething(AudioClip clip, string[] messages, string sceneName)
	{
		MusicManager.Manager.Stop();
		MusicManager.Manager.PlayOneshot(clip);
		DialogManager.Manager.SetActive(true, false, false);
		yield return StartCoroutine(DialogManager.Manager.CWriteLines(messages));
		DialogManager.Manager.ResetText();
		SceneManager2.Manager.Transition(sceneName);
	}
}