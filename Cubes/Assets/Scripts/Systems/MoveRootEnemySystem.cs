using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MoveRootEnemySystem : IExecuteSystem
{

	private Contexts _contexts;
	
	public MoveRootEnemySystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Execute()
	{
		var entity = _contexts.game.rootEnemyEntity;
		entity.position.Position += Vector2.down * Time.deltaTime * entity.move.Speed;
	}
}
