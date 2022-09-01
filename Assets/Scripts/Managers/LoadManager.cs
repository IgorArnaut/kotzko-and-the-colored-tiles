using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
	void Start()
	{
		SaveManager.Instance.Load();
	}
}
