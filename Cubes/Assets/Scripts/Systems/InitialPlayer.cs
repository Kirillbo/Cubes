using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;


public class InitialPlayer : IInitializeSystem
{
    private Contexts _ecsWorld;

    public InitialPlayer(Contexts contexts)
    {
        _ecsWorld = contexts;
    }
    
    public void Initialize()
    {
        var player = PoolManager.Instance.Get(PoolType.Player);
        _ecsWorld.game.CreateEntity();
        
//        var moveComponent = _ecsWorld.AddComponent<MoveComponent>(entity);
//        moveComponent.Transform = player.transform;
//        moveComponent.Speed = GameManager.Instance.SpeedPlayer;
        
        player.transform.position = GameManager.Instance.RespawnPos.position;
        player.SetActive(true);
        
    }

    public void Destroy()
    {
       
    }
}
