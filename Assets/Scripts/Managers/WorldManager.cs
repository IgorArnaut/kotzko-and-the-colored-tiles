using System;
using System.Collections;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
	// Components
	private AudioSource src;

	// Units
	private GameObject player;

	// Victory & Defeat
	[SerializeField]
	private string[] defeat;
	private bool once;

	void Awake()
	{
		GetComponents();
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		Defeat();
	}

	// Get Components
	private void GetComponents()
	{
		src = GetComponent<AudioSource>();
	}

	// Defeat
	private void Defeat()
	{
		if (player == null && !once)
		{
			once = true;
			MusicManager.Manager.Stop();
			MusicManager.Manager.PlayOneshot(MusicManager.Manager.clips[0]);
			DialogManager.Manager.WriteLines2(defeat);

			if (!DialogManager.Manager.running)
				SceneManager2.Manager.Transition("GameOver");
		}
	}
}
