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
        var entity = _ecsWorld.game.CreateEntity();
        
        entity.AddMove(GameManager.Instance.SpeedPlayer, Vector3.zero, player.transform);
        entity.Retain(player);
        player.transform.position = GameManager.Instance.RespawnPos.position;
        player.SetActive(true);
        
    }

    public void Destroy()
    {
       
    }
}
