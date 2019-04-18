	using System.Collections;
	using System.Collections.Generic;
	
	using Tools;
	using UnityEngine;
	
	public class ControllerRespawnEnemies 
	{
		
//		private EcsWorld _ecsWorld = null;
//		private EcsFilter<PositionComponent, EnemyComponent, DeactivateComponentttt, MoveComponent> _enemies = null;
		
		private float _actualPosY;
		private Transform _rootEnemies;
		private float _offsetSprite;
		private GameManager _gameManager;
		private int _curCountActiveBlocks = 0;
	
		
		public void Initialize()
		{
			_gameManager = GameManager.Instance;
			_rootEnemies = GameObject.Find("RootEnemies").transform;
			//_offsetSprite = _enemies.Components3[0].SpriteRenderer[0].sprite.bounds.size.y;
			_actualPosY = _gameManager.StartRespawnCubes.position.y;
			
			
		}
	
			
		public void Run()
		{
			
			//RespawnEnemy2();
			
	//		for (int i = 0; i < _enemies.EntitiesCount; i++)
	//		{
	//			
	//			var posComponent = _enemies.Components1[i];
	//			_enemies.Components4[i].Transform.position = CalculateActualPosition();
	//			_enemies.Components4[i].Transform.SetParent(_rootEnemies);
	//			_enemies.Components4[i].Transform.gameObject.SetActive(true);
	//
	//			SetHeartEnemy(_enemies.Components3[i]);
	//			
	//			_ecsWorld.RemoveComponent<DeactivateComponent>(_enemies.Entities[i]);
	//		}
			_curCountActiveBlocks++;
		}
	
		
		
		
//		void RespawnEnemy()
//		{
//			
//			var moveComponent = _enemies.Components4[0];
//			moveComponent.Transform.position = CalculateActualPosition();
//			moveComponent.Transform.SetParent(_rootEnemies);
//			moveComponent.Transform.gameObject.SetActive(true);
//	
//			//SetHeartEnemy(_enemies.Components3[0]);
//		//	_ecsWorld.RemoveEntity(_enemies.Entities[0]);
//		}
		
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
