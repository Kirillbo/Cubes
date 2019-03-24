using System.Collections;
using System.Collections.Generic;
using Componentns;
using Leopotam.Ecs;
using UnityEngine;

[EcsInject]
public class InputSystem : IEcsRunSystem
{

	private EcsFilter<MoveComponent> _moveComponents = null;
	
	public void Run()
	{
//		if (Input.GetKey(KeyCode.LeftArrow))
//		{
//			SetInputDirection(Vector3.left);
//		}
//
//		else if (Input.GetKey(KeyCode.RightArrow))
//		{
//			SetInputDirection(Vector3.right);			
//		}
//
//		else
//		{
//			SetInputDirection(Vector3.zero);
//		}
	}


	void SetInputDirection(Vector3 direction)
	{
		for (int i = 0; i < _moveComponents.EntitiesCount; i++)
		{
			_moveComponents.Components1[i].Direction = direction;
		}
	}
}
