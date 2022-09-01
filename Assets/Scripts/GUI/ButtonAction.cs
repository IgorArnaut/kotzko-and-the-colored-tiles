using UnityEngine;

public class ButtonAction : MonoBehaviour
{
	[SerializeField]
	private AudioClip clip;

	[SerializeField]
	private Stats playerStats;

	[SerializeField]
	private Inventory playerInventory;

    public void PlayGame(string sceneName)
	{
		Reset();
		GetComponent<AudioSource>().PlayOneShot(clip);
		SceneManager2.Manager.Transition(sceneName);
	}

	private void Reset()
	{
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

	public void QuitGame()
	{
		Debug.Log("Quitting game...");
		Application.Quit();
	}
}
