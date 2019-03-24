using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Componentns;
using Leopotam.Ecs;
using UnityEngine;

[EcsInject]
public class InitialEnemies : IEcsInitSystem
{
    public int CountEnemies;
    private EcsWorld _ecsWorld = null;
    
    public void Initialize()
    {
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.SmallEnemy, 15));
        enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.MediumEnemy, 7));
        enemies.AddRange(PoolManager.Instance.ReSpawn(PoolType.BigEnemy, 5));

        foreach (var enemy in enemies)
        {
            var entity = enemy.CreateEntityWithPosition(_ecsWorld);
            var moveComponent = _ecsWorld.AddComponent<MoveComponent>(entity);
            moveComponent.Transform = enemy.transform;
            moveComponent.Speed = 1;

            _ecsWorld.AddComponent<EnemyComponent>(entity);
            var renderComponent = _ecsWorld.AddComponent<RenderComponentn>(entity);
            renderComponent.SpriteRenderer = enemy.GetComponentsInChildren<SpriteRenderer>();
        }

        var rootEnemies = GameObject.Find("RootEnemies");
        var entityRootEnemies = rootEnemies.CreateEntityWithPosition(_ecsWorld);
        var moveComponentRoot = _ecsWorld.AddComponent<MoveComponent>(entityRootEnemies);
        moveComponentRoot.Transform = rootEnemies.transform;
        moveComponentRoot.Direction = Vector3.down;
        moveComponentRoot.Speed = GameManager.Instance.SpeedEnemies;
        
        
    }

    public void Destroy()
    {
        
    }
}
