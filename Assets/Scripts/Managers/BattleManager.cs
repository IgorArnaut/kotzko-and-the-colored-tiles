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
	private SceneManager2 sManager;

	[SerializeField]
	private GameObject textBox;
	[SerializeField]
	private TextMeshProUGUI dialogText;
	
	private bool running;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	void Update()
	{
		if (player == null) {
			Write(new Queue<string>(defeat));
			sManager.Transition("GameOver");
		}

		if (enemy == null) {
			Write(new Queue<string>(victory));
			sManager.Transition("Dungeon");
		}
	}

	public void Write(Queue<string> lines)
	{
		if (!running) {
			textBox.SetActive(true);
			StartCoroutine(Write(lines.Dequeue()));

			if (Input.GetKeyDown(KeyCode.E) && !running)
			{
				if (lines.Count == 0)
				{
					textBox.SetActive(false);
					return;
				}
				
				StartCoroutine(Write(lines.Dequeue()));
			}
		}
	}

	private IEnumerator Write(string line)
	{
		running = true;
		dialogText.text = "";

		foreach (char c in line)
		{
			dialogText.text += c;
			yield return new WaitForSeconds(0.01f);
		}

		running = false;
	}
}
