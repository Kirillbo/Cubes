using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem
{

//	private EcsFilter<MoveComponent> _moveComponents = null;
	private LayerMask _mask;
	private Transform _activeObject = null;
	private Camera _mainCam;
	
	private Vector2 _lastPosMouse;
	private Contexts _context;


	public void Initialize()
	{
		_mask = GameManager.Instance.Mask;
		_mainCam = Camera.main;
	}
	
	public void Run()
	{
		Vector2 curPosMouse = _mainCam.ScreenToWorldPoint(Input.mousePosition);
	
	    if(Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit;
			hit = Physics2D.Raycast(curPosMouse, Vector2.zero, _mask);

			if(hit.collider != null)
			{
				_lastPosMouse = _mainCam.ScreenToWorldPoint(Input.mousePosition);
				_activeObject = hit.transform.parent;
				_lastPosMouse = curPosMouse;
				//Debug.Log ("Target Position: " + _activeObject.name);
			}
		}
		
		else if (Input.GetMouseButtonUp(0))
	    {
		    _activeObject = null;
	    }

		if (_activeObject != null && curPosMouse != _lastPosMouse)
		{
			var _deltaMousePos = curPosMouse - _lastPosMouse;
			_activeObject.position += new Vector3(_deltaMousePos.x, 0 , 0);
		}

		_lastPosMouse = curPosMouse;

//		if (Input.GetKey(KeyCode.LeftArrow))
//		{
//			SetInputDirection(Vector3.left);
//		}
//
//		else if (Input.GetKey(KeyCode.RightArrow))
//		{
//			SetInputDirection(Vector3.right);			
//		}
//
//		else
//		{
//			SetInputDirection(Vector3.zero);
//		}
	}


	void SetInputDirection(Vector3 direction)
	{
//		for (int i = 0; i < _moveComponents.EntitiesCount; i++)
//		{
//			_moveComponents.Components1[i].Direction = direction;
//		}
	}


	public InputSystem(Contexts contexts)
	{
		_context = contexts;
	}

	public void Execute()
	{
		var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");
		_context.input.ReplaceInput(new Vector2(x,y));
	}
}
