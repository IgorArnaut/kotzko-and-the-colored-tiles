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
		finished = false;
	}

	// Get Components
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	public void SetActive(bool tb, bool z, bool x)
	{
		textBox.SetActive(tb);
		keyboard[0].SetActive(z);
		keyboard[1].SetActive(x);
	}

	// Cancels writing
	public void CancelWriting()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			keyboard[1].GetComponent<Animator>().SetTrigger("press");
			StopAllCoroutines();
			SetActive(false, false, false);
			dialogText.text = "";
			running = false;
			i = 0;
		}
	}

	// Writes a line of text
	public void WriteLine(string line)
	{
		finished = false;
		StartCoroutine(CWriteLine(line));
		SetActive(false, false, false);
	}

	// Writes a line of text (on key press)
	public void WriteLines(string[] lines)
	{
		finished = false;
		if (Input.GetKeyDown(KeyCode.E) && !running)
		{
			keyboard[0].GetComponent<Animator>().SetTrigger("press");

			if (i < lines.Length)
			{
				StartCoroutine(CWriteLine(lines[i]));
				i++;
			}
			else
			{
				SetActive(false, false, false);
				dialogText.text = "";
				i = 0;
			}
		}
	}

	// Writes lines of text
	public void WriteLines2(string[] lines)
	{
		finished = false;
		StartCoroutine(CWriteLines(lines));
	}

	// Writes a line of text in time
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

	// Writes lines of text in time
	private IEnumerator CWriteLines(string[] lines)
	{
		running = true;

		foreach (string line in lines)
		{
			StartCoroutine(CWriteLine(line));
			yield return new WaitForSeconds(1.0f);
		}

		running = false;
		SetActive(false, false, false);
		dialogText.text = "";
		i = 0;
	}
}
