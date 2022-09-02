using UnityEngine;

public class LoadManager : MonoBehaviour
{
	void Awake()
	{
		if (SaveManager.Manager != null) SaveManager.Manager.LoadData();
	}
}
