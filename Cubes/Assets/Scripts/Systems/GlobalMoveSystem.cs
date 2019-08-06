using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GlobalMoveSystem : IExecuteSystem
{

	private Contexts _contexts;
	private IGroup<GameEntity> _movable;

	public GlobalMoveSystem(Contexts contexts)
	{
		_contexts = contexts;
		_movable = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Move, GameMatcher.Position));
	}
	
	public void Execute()
	{
		foreach (var entity in _movable)
		{
			var moveComponent = entity.move;
			var positionComponent = entity.position.Position;
			moveComponent.Transform.localPosition = new Vector3(positionComponent.x, positionComponent.y);
		}
	}
}
