	using System.Collections;
	using System.Collections.Generic;
	using Entitas;
	using Tools;
	using UnityEngine;
	
	public class ControllerRespawnEnemies : IExecuteSystem, IInitializeSystem
	{
		private Contexts _contexts;
		private IGroup<GameEntity> _enemiesGroup;
		
		private float _actualPosY;
		private Transform _rootEnemies;
		private float _offsetSprite;
		private GameManager _gameManager;
		private int _curCountActiveBlocks = 0;

		public ControllerRespawnEnemies(Contexts contexts)
		{
			_contexts = contexts;
			_enemiesGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy));
		}
		
		public void Initialize()
		{
			_gameManager = GameManager.Instance;
			_rootEnemies = GameObject.Find("RootEnemies").transform;
			_offsetSprite = _enemiesGroup.GetEntities()[0].renderComponentn.SpriteRenderer[0].sprite.bounds.size.y;
			Debug.Log(_offsetSprite);
			_actualPosY = _gameManager.StartRespawnCubes.position.y;
			
			
			for (int i = 0; i < _enemiesGroup.count; i++)
			{

				var entityEnemy = _enemiesGroup.GetEntities()[i];
				var posComponent = entityEnemy.move.Transform;
				posComponent.position = CalculateActualPosition();
				posComponent.SetParent(_rootEnemies);

				var render = entityEnemy.renderComponentn;
				SetHeartEnemy(render);
				posComponent.gameObject.SetActive(true);
				_curCountActiveBlocks++;				
			}
			
		}
	
			
		public void Execute()
		{
						
//			for (int i = 0; i < _enemiesGroup.count; i++)
//			{
//
//				var entityEnemy = _enemiesGroup.GetEntities()[i];
//				var posComponent = entityEnemy.move.Transform;
//				posComponent.position = CalculateActualPosition();
//				posComponent.SetParent(_rootEnemies);
//
//				var render = entityEnemy.renderComponentn;
//				SetHeartEnemy(render);
//				posComponent.gameObject.SetActive(true);
//				_curCountActiveBlocks++;				
//			}
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
	
		public void Destroy()
		{
			throw new System.NotImplementedException();
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
