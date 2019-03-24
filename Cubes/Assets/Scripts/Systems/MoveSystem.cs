using System.Collections;
using System.Collections.Generic;
using Componentns;
using Leopotam.Ecs;
using UnityEngine;

[EcsInject]
public class MoveSystem : IEcsRunSystem
{

	private EcsFilter<MoveComponent> _ecsFilter = null;

	public void Run()
	{
			
		for(int i = 0; i < _ecsFilter.EntitiesCount; i++)
		{
			var moveComponent = _ecsFilter.Components1[i];
			moveComponent.Transform.position += moveComponent.Direction * Time.deltaTime * moveComponent.Speed;
		}		
	}
}
