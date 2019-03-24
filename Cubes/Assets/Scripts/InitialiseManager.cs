using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseManager : MonoBehaviour
{
    
    public GameObject PlayerPrefab;
	public GameObject SmallEnemyPrefab;
	public GameObject MeduimEnemyPrefab;
	public GameObject BigEnemyPrefab;

	public void CreateAllPools ()
	{
	    PoolManager.Instance.CreatePool(PoolType.Player, 1, PlayerPrefab);
		PoolManager.Instance.CreatePool(PoolType.SmallEnemy, 15, SmallEnemyPrefab);
		PoolManager.Instance.CreatePool(PoolType.MediumEnemy, 11, MeduimEnemyPrefab);
		PoolManager.Instance.CreatePool(PoolType.BigEnemy, 7, BigEnemyPrefab);

	}
	
}
