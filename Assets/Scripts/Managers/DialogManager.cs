using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
	public static DialogManager Manager;

	public GameObject textBox;
	public TextMeshProUGUI dialogText;

	private int i;
	private bool running;

	[SerializeField]
	private AudioClip clip;

	void Awake()
	{
		Manager = this;
	}

	void Start()
	{
		i = 0;
	}

	public void Write(string[] lines)
	{
		textBox.SetActive(true);

		if (Input.GetKeyDown(KeyCode.E) && !running)
		{
			if (i < lines.Length)
			{
				StartCoroutine(Write(lines[i]));
				i++;
			}
			else
			{
				i = 0;
				dialogText.text = "";
				textBox.SetActive(false);
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
			GetComponent<AudioSource>().PlayOneShot(clip);
			yield return new WaitForSeconds(0.05f);
		}

		running = false;
	}
}
