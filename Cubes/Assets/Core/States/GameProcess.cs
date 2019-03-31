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

        var entity = contexts.game.CreateEntity();
        entity.AddPosition(Vector2.zero, true);
        
        
        
        _system.Add(new InitialPlayer(contexts));
//                Add(new InitialEnemies()).
//                Add(new MoveSystem()).
//                Add(new InputSystem()).
//                Add(new ControllerRespawnEnemies());
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
