using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
	public String[] lines;
	private bool dialog;
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
		if (dialog && !once)
		{
			once = true;
			DialogManager.Manager.WriteLines2(lines);
		}
	}

	// Pokrece dijalog
	public void StartDialog()
	{
		dialog = true;
		DialogManager.Manager.SetActive(true, false, false);
	}

	// Resetuje dijalog
	public void ResetDialog()
	{
		DialogManager.Manager.ResetText();
	}
}
