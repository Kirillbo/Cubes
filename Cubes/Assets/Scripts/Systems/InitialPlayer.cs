using System.Collections;
using System.Collections.Generic;
using Componentns;
using Leopotam.Ecs;
using UnityEngine;
using Leopotam.Ecs;


[EcsInject]
public class InitialPlayer : IEcsInitSystem
{
    private EcsWorld _ecsWorld = null;

    public void Initialize()
    {
        var player = PoolManager.Instance.Get(PoolType.Player);
        var entity = player.CreateEntityWithPosition(_ecsWorld);
        _ecsWorld.CreateEntity();
        
        var moveComponent = _ecsWorld.AddComponent<MoveComponent>(entity);
        moveComponent.Transform = player.transform;
        moveComponent.Speed = GameManager.Instance.SpeedPlayer;
        
        player.transform.position = GameManager.Instance.RespawnPos.position;
        player.SetActive(true);
        
    }

    public void Destroy()
    {
       
    }
}
