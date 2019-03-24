using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnWall : MonoBehaviour {
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		PoolManager.Instance.DeSpawn(PoolType.Enemies, other.gameObject);
	}
}
