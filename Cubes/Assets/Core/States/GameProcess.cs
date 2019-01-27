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
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Tick()
    {
        throw new System.NotImplementedException();
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
