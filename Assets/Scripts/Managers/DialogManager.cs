using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
	public static DialogManager Manager;

	public GameObject textBox;
	[SerializeField]
	private TextMeshProUGUI dialogText;
	
	private bool running;

	void Awake()
	{
		Manager = this;
	}

	public void Write(Queue<string> lines)
	{
		textBox.SetActive(true);

		if (Input.GetKeyDown(KeyCode.E) && !running)
			StartCoroutine(Write(lines.Peek()));
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
