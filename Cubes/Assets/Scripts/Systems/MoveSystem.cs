using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
	private Contexts _pool;
	private Group _movableGroup;

	public MoveSystem(Contexts contexts)
	{
		_pool = contexts;
	}

	public void Execute()
	{
//		for(int i = 0; i < _ecsFilter.EntitiesCount; i++)
//		{
//			var moveComponent = _ecsFilter.Components1[i];
//			moveComponent.Transform.position += moveComponent.Direction * Time.deltaTime * moveComponent.Speed;
//		}
//
//	
//		Debug.Log(kek.EntitiesCount);
//
//		for (int i = 0; i < kek.EntitiesCount-1; i++)
//		{
//			_ecsWorld.RemoveComponent<DeactivateComponentttt>(kek.Entities[i]);
//		}
	}
}
