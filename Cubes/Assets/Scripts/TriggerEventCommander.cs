using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using UnityEngine;

public class TriggerEventCommander : MonoBehaviour {
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			var entity = Contexts.sharedInstance.game.CreateEntity();
			entity.AddCollider(gameObject.transform, other.transform, false);
		}
		
		else if (other.CompareTag("HeartEnemy"))
		{
			var entity = Contexts.sharedInstance.game.CreateEntity();
			entity.AddCollider(gameObject.transform, other.transform, true);
		}
	}
}
