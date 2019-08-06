	using System.Collections;
	using System.Collections.Generic;
	using Entitas;
	using Tools;
	using UnityEngine;
	
	public class ControllerRespawnEnemies : IExecuteSystem, IInitializeSystem
	{
		private Contexts _contexts;
		private IGroup<GameEntity> _enemiesGroup;
		private IGroup<GameEntity> _enemiesOnScene;
		
		private float _actualPosY;
		private Transform _rootEnemies;
		private float _offsetSprite;
		private GameManager _gameManager;
		private int _curCountActiveBlocks = 0;
		
		public ControllerRespawnEnemies(Contexts contexts, int countEnemiesOnScene)
		{
			_contexts = contexts;
			_enemiesGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Deactivate));
			_enemiesOnScene = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Active));
			_curCountActiveBlocks = countEnemiesOnScene;
		}
		
		public void Initialize()
		{
			_gameManager = GameManager.Instance;
			_rootEnemies = GameObject.Find("RootEnemies").transform;
			_offsetSprite = _enemiesGroup.GetEntities()[0].renderComponentn.SpriteRenderer[0].sprite.bounds.size.y;
			_actualPosY = _gameManager.StartRespawnCubes.position.y;			
		}
	
			
		public void Execute()
		{
			Debug.Log("ALL Enemy " +_enemiesGroup.count);
			Debug.Log("ACTIVE ENEMY " + _enemiesOnScene.count);
			if(_enemiesOnScene.count > _curCountActiveBlocks) return;

			RespawnEnemy();
		}

		void RespawnEnemy()
		{
			var entityEnemy = _enemiesGroup.GetEntities()[0];
			var moveComponent = entityEnemy.move.Transform;
			moveComponent.SetParent(_rootEnemies);
				
			var posComponent = entityEnemy.position;
			posComponent.Position = CalculateActualPosition();

			var render = entityEnemy.renderComponentn;
			SetHeartEnemy(render);
			entityEnemy.isActive = true;
		}
				
		Vector2 CalculateActualPosition()
		{
			if(ToolsRandom.Choice(0.4f))
				_actualPosY += _offsetSprite * 2;
			else
			{
				_actualPosY += _offsetSprite;
			}
	
			var x = Random.Range(_gameManager.EdgeScreen, -_gameManager.EdgeScreen);
			return new Vector2(x, _actualPosY);
		}
	
	
		void SetHeartEnemy(RenderComponentn renderComponent)
		{
			var renders = renderComponent.SpriteRenderer;
			foreach (var render in renders)
			{
				render.sprite = _gameManager.SpriteBlueEnemy;
				render.tag = "Enemy";
			}
	
			var indexHeart = Random.Range(0, renders.Length);
			renders[indexHeart].sprite = _gameManager.SpriteRedEnemy;
			renders[indexHeart].tag = "HeartEnemy";
		}

	}
