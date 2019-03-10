using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using Leopotam.Ecs;
using UnityEngine;


[EcsInject]
public class InitialPlayer : IEcsInitSystem
{
    private EcsWorld _ecsWorld = null;

    public void Initialize()
    {
        var player = PoolManager.Instance.Get(PoolType.Player);
        var entity = player.CreateEntityWithPosition(_ecsWorld);
        

    }

    public void Destroy()
    {
       
    }
}
