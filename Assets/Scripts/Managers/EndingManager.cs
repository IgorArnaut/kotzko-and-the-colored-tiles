using System;
using System.Collections;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
	public String[] messages;
	private bool once;

	void Awake()
	{
		ResetManager.Manager.ResetData();
	}

	void Start()
	{
		once = false;
	}

	void Update()
	{
		if (!once)
		{
			once = true;
			StartCoroutine(CStartDialog());
		}
	}

	// Pokrece dijalog
	private IEnumerator CStartDialog()
	{
		yield return new WaitForSeconds(1.0f);
		DialogManager.Manager.SetActive(true, false, false);
		yield return StartCoroutine(DialogManager.Manager.CWriteLines(messages));
		DialogManager.Manager.ResetText();
	}
}
