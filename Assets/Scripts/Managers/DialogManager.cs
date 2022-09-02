using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
	// Manager
	public static DialogManager Manager;

	// Compoentns
	private AudioSource src;

	// Text box
	public GameObject textBox;
	public TextMeshProUGUI dialogText;

	// Write text
	[SerializeField]
	public AudioClip clip;
	[SerializeField]
	public GameObject[] keyboard;
	public bool running;
	public bool finished;
	private int i;


	void Awake()
	{
		Manager = this;
		GetComponents();
	}

	void Start()
	{
		i = 0;
	}

	// Get Components
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Stop writing
	public void StopWriting()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			keyboard[1].GetComponent<Animator>().SetTrigger("press");
			StopAllCoroutines();

			textBox.SetActive(false);
			foreach (GameObject key in keyboard) key.SetActive(false);

			dialogText.text = "";
			running = false;
			i = 0;
		}
	}

	// Write text
	public void WriteLine(string line)
	{
		textBox.SetActive(true);
		StartCoroutine(CWriteLine(line));
		textBox.SetActive(false);
	}

	public void WriteLines(string[] lines)
	{
		textBox.SetActive(true);
		foreach (GameObject key in keyboard) key.SetActive(true);

		if (Input.GetKeyDown(KeyCode.Z) && !running)
		{
			keyboard[0].GetComponent<Animator>().SetTrigger("press");

			if (i < lines.Length)
			{
				StartCoroutine(CWriteLine(lines[i]));
				i++;
			}
			else
			{
				textBox.SetActive(false);
				foreach (GameObject key in keyboard) key.SetActive(false);

				dialogText.text = "";
				i = 0;
			}
		}
	}

	public void WriteLines2(string[] lines)
	{
		textBox.SetActive(true);
		StartCoroutine(CWriteLines(lines));
		textBox.SetActive(false);
	}

	// Coroutines
	private IEnumerator CWriteLine(string line)
	{
		running = true;
		dialogText.text = "*<indent=4%> ";

		foreach (char c in line)
		{
			src.PlayOneShot(clip);
			dialogText.text += c;
			yield return new WaitForSeconds(0.03f);
		}

		dialogText.text += "</indent>";
		running = false;
	}

	private IEnumerator CWriteLines(string[] lines)
	{
		finished = false;
		running = true;

		foreach (string line in lines)
		{
			CWriteLine(line);
			yield return new WaitForSeconds(1.0f);
		}

		running = false;
		finished = true;
	}
}
