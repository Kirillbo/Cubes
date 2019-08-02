using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;


public class InitialPlayer : IInitializeSystem
{
    private Contexts _contexts;

    public InitialPlayer(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Initialize()
    {
        var player = PoolManager.Instance.Get(PoolType.Player);
        var entityPlayer = _contexts.game.CreateEntity();

        entityPlayer.isPlayer = true;
        entityPlayer.AddMove(GameManager.Instance.SpeedPlayer, Vector3.zero, player.transform);
        entityPlayer.Retain(player);
        player.transform.position = GameManager.Instance.RespawnPos.position;
        player.Link(entityPlayer);
        player.SetActive(true);
        
    }

    public void Destroy()
    {
       
    }
}
