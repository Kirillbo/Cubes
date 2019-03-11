﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseManager : MonoBehaviour
{
    
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

	// Use this for initialization
	public void CreatAllPools ()
	{
	    PoolManager.Instance.CreatePool(PoolType.Player, 1, PlayerPrefab);
	}
	
}