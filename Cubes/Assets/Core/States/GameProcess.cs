using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class GameProcess : AState
{

    public EcsSystems System;

    public override void Init()
    {
       System = new EcsSystems(Manager.EcsWorld);

#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(System);
#endif

        System.Add(new InitialPlayer()).
               Add(new InitialEnemies()).
               Add(new MoveSystem()).
               Add(new InputSystem()).
               Add(new ControllerRespawnEnemies());
        System.Initialize();
    }

    public override void Enter()
    {
      //  throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    private int i = 0;
    
    public override void Tick()
    {
        i += 1;
        if (i % 100 == 0)
        {
            System.Run();
            i = 0;
        }
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
