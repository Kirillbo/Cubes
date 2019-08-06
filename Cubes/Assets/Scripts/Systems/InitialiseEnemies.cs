using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class InitialiseEnemies : IInitializeSystem
{
	private Contexts _contexts;
	private IGroup<GameEntity> _enemies;
		
	private float _actualPosY;
	private Transform _rootEnemies;
	private float _offsetSprite;
	private GameManager _gameManager;
	private int _curCountActiveBlocks = 0;
	private int _startCountEnemy;
	
	public InitialiseEnemies(Contexts contexts)
	{
		_contexts = contexts;
//		_startCountEnemy = countEnemy;
	}

	public void Initialize()
	{
		_gameManager = GameManager.Instance;
		_rootEnemies = GameObject.Find("RootEnemies").transform;

		var allEnemies = PoolManager.Instance.GetStack(PoolType.Enemy);
		foreach (var enemy in allEnemies)
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddMove(1, enemy.transform);
			entity.AddRenderComponentn(enemy.GetComponentsInChildren<SpriteRenderer>());
			entity.AddPosition(Vector2.zero);
			entity.isDeactivate = true;
			var countBlock = enemy.GetComponentsInChildren<SpriteRenderer>();
			entity.AddEnemy(countBlock.Length);
			enemy.Link(entity);
		}

		var entityRootEnemies = _contexts.game.CreateEntity();
		entityRootEnemies.isRootEnemy = true;
		entityRootEnemies.AddMove(GameManager.Instance.SpeedEnemies, _rootEnemies.transform);
		entityRootEnemies.AddPosition(Vector2.zero);
		_rootEnemies.gameObject.Link(entityRootEnemies);
	}
	
		
}
