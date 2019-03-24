using System.Collections;
using System.Collections.Generic;
using Componentns;
using Leopotam.Ecs;
using Tools;
using UnityEngine;

[EcsInject]
public class ControllerRespawnEnemies : IEcsInitSystem, IEcsRunSystem
{

	private EcsFilter<PositionComponent, EnemyComponent, RenderComponentn, MoveComponent> _enemies = null;
	private float _actualPosY;
	private Transform _rootEnemies;
	private float _offsetSprite;
	private GameManager _gameManager;
	
	public void Initialize()
	{
		_gameManager = GameManager.Instance;
		_rootEnemies = GameObject.Find("RootEnemies").transform;
		_offsetSprite = _enemies.Components3[0].SpriteRenderer[0].sprite.bounds.size.y;
	}

		
	public void Run()
	{
		for (int i = 0; i < _enemies.EntitiesCount; i++)
		{
			
			var posComponent = _enemies.Components1[i];
			if(posComponent.ChangePosition) continue;
			posComponent.ChangePosition = true;
			_enemies.Components4[i].Transform.position = CalculateActualPosition();
			_enemies.Components4[i].Transform.SetParent(_rootEnemies);
			_enemies.Components4[i].Transform.gameObject.SetActive(true);

			SetHeartEnemy(_enemies.Components3[i]);
		}
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

		var indexHeart = Random.Range(0, renders.Length + 1);
		renders[indexHeart].sprite = _gameManager.SpriteRedEnemy;
		renders[indexHeart].tag = "HeartEnemy";
	}
}
