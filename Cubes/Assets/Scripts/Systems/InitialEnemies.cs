using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Entitas;
using UnityEngine;

public class InitialEnemies : IInitializeSystem
{
    public int CountEnemies;
    private Contexts _ecsWorld;

    public InitialEnemies(Contexts contexts)
    {
        _ecsWorld = contexts;
    }
    
    public void Initialize()
    {
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.SmallEnemy, 15));
        enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.MediumEnemy, 7));
        enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.BigEnemy, 5));

        foreach (var enemy in enemies)
        {
            var entity = _ecsWorld.game.CreateEntity();
            entity.AddMove(1, Vector3.zero, enemy.transform);
            entity.isEnemy = true;
            entity.AddRenderComponentn(enemy.GetComponentsInChildren<SpriteRenderer>());
            
        }

        var rootEnemies = GameObject.Find("RootEnemies");
        var entityRootEnemies = _ecsWorld.game.CreateEntity();
        entityRootEnemies.AddMove(GameManager.Instance.SpeedEnemies, Vector3.down, rootEnemies.transform);

    }


}
