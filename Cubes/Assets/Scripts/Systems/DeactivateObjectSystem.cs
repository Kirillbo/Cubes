using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DeactivateObjectSystem : ReactiveSystem<GameEntity>
{

	private Contexts _contexts;
	
	public DeactivateObjectSystem(Contexts context) : base(context.game)
	{
		_contexts = context;
	}


	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Active.Removed());
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasMove;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		Debug.Log("work deactivate");
		foreach (var e in entities)
		{
			e.move.Transform.gameObject.SetActive(false);
			e.isDeactivate = true;
		}
	}
}
