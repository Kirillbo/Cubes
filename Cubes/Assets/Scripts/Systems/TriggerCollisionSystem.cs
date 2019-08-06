using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class TriggerCollisionSystem : ReactiveSystem<GameEntity>
{

	private Contexts _contexts;
	
	public TriggerCollisionSystem(Contexts contexts) : base(contexts.game)
	{
		_contexts = contexts;
	}


	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Collider);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasCollider;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var colComponent = e.collider;
			var secondEntity = _contexts.game.GetEntitiesWithMove(colComponent.SecondObject.parent);
			if (colComponent.DamageHeart)
			{
				
			}

			foreach (var entity in secondEntity)
				entity.isActive = false;

			e.Destroy();
		}
	}
}
