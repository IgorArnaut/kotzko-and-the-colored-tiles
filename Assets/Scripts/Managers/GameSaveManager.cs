using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveManager : MonoBehaviour
{
	public static GameSaveManager instance;

	public GameObject player;
	public GameObject[] greenTiles;
	public GameObject[] chests;
	public GameObject[] gates;

	public Progress progress;
}
