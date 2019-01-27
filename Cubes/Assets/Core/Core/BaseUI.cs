using System;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour, IReceive<EventClickButton>
{

	protected Vector2 StartPosition;
	
	protected virtual void Start()
	{
		EventManager.Instance.Add<EventClickButton>(this);
		StartPosition = transform.localPosition;
	}

	public virtual void Init()
	{
		
	}
	
	public virtual void Show()
	{

		gameObject.SetActive(true);
		if (OnOpen != null) OnOpen();
	}

	public virtual void Close()
	{
		gameObject.SetActive(false);
		if (OnClose != null) OnClose();
	}

	public abstract TypeCanvas GetTypeCanvas();
	
	public event Action OnOpen;
	public event Action OnClose;


	public abstract void HandleSignal(EventClickButton arg);

}

public enum TypeCanvas
{
	Static,
	Dynamic
}
