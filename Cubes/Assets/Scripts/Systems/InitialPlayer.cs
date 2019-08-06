using Entitas;
using Entitas.Unity;


public class InitialPlayer : IInitializeSystem
{
    private Contexts _contexts;

    public InitialPlayer(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Initialize()
    {
        var player = PoolManager.Instance.Get(PoolType.Pike);
        var entityPlayer = _contexts.game.CreateEntity();

        entityPlayer.isPlayer = true;
        entityPlayer.AddMove(GameManager.Instance.SpeedPlayer, player.transform);
        entityPlayer.Retain(player);
        player.transform.position = GameManager.Instance.RespawnPos.position;
        player.Link(entityPlayer);
        player.SetActive(true);
        
    }

    public void Destroy()
    {
       
    }
}
