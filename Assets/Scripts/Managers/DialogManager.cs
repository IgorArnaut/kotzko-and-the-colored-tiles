using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
	// Instanca
	public static DialogManager Manager;

	// Komponente
	public AudioSource src;

	// Kutija za text
	public GameObject textBox;
	public TextMeshProUGUI dialogText;

	// Pisanje teksta
	public AudioClip clip;
	public GameObject[] keyboard;
	private bool running;
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

	// Uzima komponente
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

	// Prekida pisanje
	public void CancelWriting()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			keyboard[1].GetComponent<Animator>().SetTrigger("press");
			StopAllCoroutines();
			ResetText();
		}
	}

	// Resetuje tekst
	public void ResetText()
	{
		SetActive(false, false, false);
		dialogText.text = "";
		running = false;
		i = 0;
	}

	// Pise liniju teksta
	public void WriteLine(string line)
	{
		StartCoroutine(CWriteLine(line));
	}

	// Pise liniju teksta na dugme
	public void WriteLines(string[] lines)
	{
		if (Input.GetKeyDown(KeyCode.E) && !running)
		{
			keyboard[0].GetComponent<Animator>().SetTrigger("press");

			if (i < lines.Length)
			{
				StartCoroutine(CWriteLine(lines[i]));
				i++;
			}
			else ResetText();
		}
	}

	// Pise linije teksta
	public void WriteLines2(string[] lines)
	{
		StartCoroutine(CWriteLines(lines));
	}

	// Pise liniju teksta karakter po karakter
	private IEnumerator CWriteLine(string line)
	{
		running = true;
		dialogText.text = "*<indent=4%>";

		foreach (char c in line)
		{
			src.PlayOneShot(clip);
			dialogText.text += c;
			yield return new WaitForSeconds(0.03f);
		}

		dialogText.text += "</indent>";
		running = false;
	}

	// Pise linije teksta karakter po karakter
	private IEnumerator CWriteLines(string[] lines)
	{
		running = true;

		foreach (string line in lines)
		{
			dialogText.text = "*<indent=4%>";

			foreach (char c in line)
			{
				src.PlayOneShot(clip);
				dialogText.text += c;
				yield return new WaitForSeconds(0.03f);
			}

			dialogText.text += "</indent>";
			yield return new WaitForSeconds(1.0f);
		}

		running = false;
		ResetText();
	}
}
