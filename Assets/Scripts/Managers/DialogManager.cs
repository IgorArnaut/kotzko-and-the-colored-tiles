using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
	public GameObject textBox;
	[SerializeField]
	private TextMeshProUGUI dialogText;
	
	private bool running;

	public void Write(Queue<string> lines)
	{
		textBox.SetActive(true);

		if (Input.GetKeyDown(KeyCode.E) && !running)
		{
			StartCoroutine(Write(lines.Dequeue()));
			
			if (lines.Count < 0)
			{
				textBox.SetActive(false);
				return;
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
