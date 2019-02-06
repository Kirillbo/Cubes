using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Tools;
using Leopotam.Ecs;
using UnityEngine;


public class GameManager : SingltoonBehavior<GameManager>
{

       
    [Header("OpenFields")]
    public AState[] States;
    public Dictionary<string, AState> StateDictionary;
    [Space(10)]
    
    [HideInInspector] public PoolManager Pool;
    private AState _activeState;

    public EcsWorld EcsWorld;
    
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
       EcsWorld = new EcsWorld();
       EcsWorld.CreateEntity();
        
       InitAllStates(States);
        
        Timer.Add(0.1f, ()=> InstanceState("StateGame"));
        //Timer.Add(0.1f, ()=> InstanceState("Start"));
     }

    void InitAllStates(AState[] states)
    {
        StateDictionary = new Dictionary<string, AState>();
        StateDictionary.Clear();
        
        foreach (var state in States)
        {
            state.Manager = this;
            state.Init();
            StateDictionary.Add(state.GetName(), state);
        }

    }
    
    
    public AState GetCurrentState()
    {
        return _activeState;
    }

    public string GetNameCurrentState()
    {
       return GetCurrentState().GetName();
    }

    public AState FindState(string stateName)
    {   
        AState s;
        if (!StateDictionary.TryGetValue(stateName, out s))
        {
            Debug.Log("This state not find");
            return null;
        }
        return s;
    }


    public AState InstanceState(string stateName)
    {
        _activeState = FindState(stateName);
        _activeState.Enter();
        Debug.Log("Init " + _activeState.GetName());
        return _activeState;
    }
    
    public void  ChangeState(string newState, float delayBetweenState = 0)
    {
        if (newState == null)
        {
            _activeState.Exit();
            _activeState = null;
            return;
        }

        _activeState.Exit();
        _activeState = FindState(newState);

        if (delayBetweenState == 0)
        {
            _activeState.Enter();
        }
        else
        {
            Timer.Add(delayBetweenState, _activeState.Enter);
        }

        Debug.Log("Current Game State - " + _activeState);
    }

   
    public void ClearScenes()
    {        
        foreach (var s in States)
            s.Clear();
      // ManagerView.Instance.Get<UIGameProcess>().ShowPanelTap();
    }
    
    void Update () {

        if(_activeState == null) return;
        _activeState.Tick();
        
    }

    private void OnDestroy()
    {

    }
}
