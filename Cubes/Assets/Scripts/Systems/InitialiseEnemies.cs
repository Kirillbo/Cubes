using System.Collections;
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
	
	public InitialiseEnemies(Contexts contexts, int countEnemy)
	{
		_contexts = contexts;
		_startCountEnemy = countEnemy;
	}

	public void Initialize()
	{
		_gameManager = GameManager.Instance;
		_rootEnemies = GameObject.Find("RootEnemies").transform;

		var enemies = new List<GameObject>();
		enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.SmallEnemy, 15));
		enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.MediumEnemy, 7));
		enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.BigEnemy, 5));

		foreach (var enemy in enemies)
		{
			var entity = _contexts.game.CreateEntity();
			entity.isEnemy = true;
			entity.AddMove(1, Vector3.zero, enemy.transform);
			entity.AddRenderComponentn(enemy.GetComponentsInChildren<SpriteRenderer>());
			entity.AddPosition(Vector2.zero);
			enemy.Link(entity);

		}

		var entityRootEnemies = _contexts.game.CreateEntity();
		entityRootEnemies.isRootEnemy = true;
		entityRootEnemies.AddMove(GameManager.Instance.SpeedEnemies, Vector3.down, _rootEnemies.transform);
		_rootEnemies.gameObject.Link(entityRootEnemies);
	}
	
		
}
