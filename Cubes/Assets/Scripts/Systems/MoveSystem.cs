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
			_ecsFilter.Components1[i].Transform.position += Vector3.left * Time.deltaTime * 2;
		}		
	}
}
