using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
	[SerializeField]
	private SceneManager2 manager;

    public void PlayGame(string sceneName)
	{
		manager.Transition(sceneName);
	}

	public void QuitGame()
	{
		Debug.Log("Quitting game...");
		Application.Quit();
	}
}
