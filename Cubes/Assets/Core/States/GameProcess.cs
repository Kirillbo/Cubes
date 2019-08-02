using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameProcess : AState
{

    private Systems  _system;

    public override void Init()
    {
        _system = new Systems();
        Contexts contexts = Contexts.sharedInstance;

        _system.Add(new InitialPlayer(contexts)).
                Add(new InputSystem(contexts)).
                Add(new MoveSystemPlayer(contexts)).
                Add(new InitialiseEnemies(contexts, 30)).
                Add(new GlobalMoveSystem(contexts)).
                Add(new ControllerRespawnEnemies(contexts));

    }

    public override void Enter()
    {
        _system.Initialize();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    private int i = 0;
    
    public override void Tick()
    {
        _system.Execute();
        _system.Cleanup();
    }

    public override void Clear()
    {
        throw new System.NotImplementedException();
    }

    public override string GetName()
    {
        return "GameProcess";
    }
}
