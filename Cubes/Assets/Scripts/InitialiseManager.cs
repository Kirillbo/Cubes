using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseManager : MonoBehaviour
{
    
    public GameObject PlayerPrefab;
	public GameObject SmallEnemyPrefab;
	public GameObject MeduimEnemyPrefab;
	public GameObject BigEnemyPrefab;

	public GameObject[] allEnemyPrefabs;
	
	public void CreateAllPools ()
	{
	    PoolManager.Instance.CreatePool(PoolType.Pike, 1, PlayerPrefab);
		PoolManager.Instance.CreatePool(PoolType.Enemy, 1, allEnemyPrefabs[0]);
		
		foreach (var element in allEnemyPrefabs)
		{
			var objects = InstanceArray(element, 10);
			PoolManager.Instance.AddObjects(PoolType.Enemy, objects);
		}
		
		PoolManager.Instance.MixObject(PoolType.Enemy);
	}

	GameObject[] InstanceArray(GameObject element, int countElement)
	{
		GameObject[] arr = new GameObject[countElement];
		for (int i = 0; i < countElement; i++)
		{
			arr[i] = Instantiate(element);
			arr[i].SetActive(false);
		}
		return arr;
	}
	
}
