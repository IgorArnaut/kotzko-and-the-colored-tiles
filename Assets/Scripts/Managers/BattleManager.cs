using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
	[SerializeField]
	private List<string> defeat;
	[SerializeField]
	private List<string> victory;

	private GameObject player;
	private GameObject enemy;

	[SerializeField]
	private GameObject textBox;
	[SerializeField]
	private TextMeshProUGUI dialogText;

	private bool once;

	void Start()
	{
		once = false;
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	void Update()
	{
		if (player == null && !once) {
			once = true;

			StartCoroutine(Write(defeat, "GameOver"));
		}

		if (enemy == null && !once) {
			once = true;

			StartCoroutine(Write(victory, "Dungeon"));
		}
	}

	private IEnumerator Write(List<string> lines, string sceneName)
	{
		yield return new WaitForSeconds(1.0f);
		textBox.SetActive(true);

		foreach (string line in lines)
		{
			dialogText.text = "";

			foreach (char c in line)
			{
				dialogText.text += c;
				yield return new WaitForSeconds(0.01f);
			}
			
			yield return new WaitForSeconds(1.0f);
		}

		textBox.SetActive(false);
		SceneManager2.sManager2.Transition(sceneName);
	}
}
