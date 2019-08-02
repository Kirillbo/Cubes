using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MoveSystemPlayer : IExecuteSystem
{
	private Contexts _pool;

	public MoveSystemPlayer(Contexts contexts)
	{
		_pool = contexts;
	}

	public void Execute()
	{
		var posX = _pool.input.input.Value.x;
		var playerTransform = _pool.game.playerEntity.move.Transform;
		var speedPlayer = _pool.game.playerEntity.move.Speed;
		playerTransform.position += new Vector3(posX, 0) * Time.deltaTime * speedPlayer;
	}
}
