using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem, IInitializeSystem
{

	private LayerMask _mask;
	private Camera _mainCam;
	
	private Vector2 _lastPosMouse;
	private Contexts _context;
	private IGroup<GameEntity> _groupEnemy;
	private HashSet<GameEntity> _selectedEnemy;
	
	public void Initialize()
	{
		_mask = GameManager.Instance.Mask;
		_mainCam = Camera.main;
	}
	

	public InputSystem(Contexts contexts)
	{
		_context = contexts;
		_groupEnemy = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy));
	}

	public void Execute()
	{
		Vector2 curPosMouse = _mainCam.ScreenToWorldPoint(Input.mousePosition);
	
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit;
			hit = Physics2D.Raycast(curPosMouse, Vector2.zero, _mask);

			if(hit.collider != null)
			{
				_lastPosMouse = _mainCam.ScreenToWorldPoint(Input.mousePosition);
				var activeObject = hit.transform.parent;
				_selectedEnemy = _context.game.GetEntitiesWithMove(activeObject);
				_lastPosMouse = curPosMouse;
			}
		}
		
		else if (Input.GetMouseButtonUp(0))
		{
			_selectedEnemy = null;
		}

		if (_selectedEnemy != null && curPosMouse != _lastPosMouse)
		{
			var deltaMousePos = curPosMouse - _lastPosMouse;

			foreach (var enemy in _selectedEnemy)
			{
				enemy.position.Position += new Vector2(deltaMousePos.x, 0 );
			}
		}

		_lastPosMouse = curPosMouse;
		
		var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");
		_context.input.ReplaceInput(new Vector2(x,y));
	}
}
