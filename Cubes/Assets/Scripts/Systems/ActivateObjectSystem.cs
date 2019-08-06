using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ActivateObjectSystem : ReactiveSystem<GameEntity>
{

	private Contexts _contexts;
	

	public ActivateObjectSystem(Contexts context) : base(context.game)
	{
		_contexts = context;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Active, GameMatcher.Move));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isActive && entity.hasMove;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			e.move.Transform.gameObject.SetActive(true);
			e.isDeactivate = false;
		}
	}
}
