using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
	[SerializeField]
	private string[] defeat;
	[SerializeField]
	private string[] victory;

	private GameObject player;
	private GameObject enemy;

	[SerializeField]
	private GameObject textBox;
	[SerializeField]
	private TextMeshProUGUI dialogText;

	private bool once;

	[SerializeField]
	private AudioClip clip;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	void Update()
	{
		LoseWin();
	}

	private void LoseWin()
	{
		if (player == null && !once)
		{
			once = true;

			MusicManager.Manager.Stop();
			MusicManager.Manager.PlayOneshot(MusicManager.Manager.clips[0]);
			
			StartCoroutine(Write(defeat, "GameOver"));
		}

		if (enemy == null && !once) {
			once = true;

			MusicManager.Manager.Stop();
			MusicManager.Manager.PlayOneshot(MusicManager.Manager.clips[1]);
			
			StartCoroutine(Write(victory, "Dungeon"));
		}
	}

	private IEnumerator Write(string[] lines, string sceneName)
	{
		yield return new WaitForSeconds(2.0f);
		textBox.SetActive(true);

		foreach (string line in lines)
		{
			dialogText.text = "";

			foreach (char c in line)
			{
				dialogText.text += c;
				GetComponent<AudioSource>().PlayOneShot(clip);
				yield return new WaitForSeconds(0.05f);
			}
			
			yield return new WaitForSeconds(1.0f);
		}

		textBox.SetActive(false);
		SceneManager2.Manager.Transition(sceneName);
	}
}
