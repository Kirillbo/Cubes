using System.Linq;
using System.Collections.Generic;
using PoolComponents;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolManager : SingltoonBehavior<PoolManager>
{

    public bool DynamicPool;
    
	private Dictionary<int, Pool> _dictionaryPools = new Dictionary<int, Pool>();
    private Dictionary<int, IComponent> _dictComponent = new Dictionary<int, IComponent>();
    
    
    
    public Pool CreatePool(PoolType id, int amount, GameObject prefabe, Transform parent = null)
    {
        Pool pool;
        int IntID = (int) id;
        var newParent = parent ? transform : parent;
        
            
        if(!_dictionaryPools.ContainsKey(IntID))
        {
            pool = new Pool(IntID, amount, prefabe, newParent);
            _dictionaryPools.Add(IntID, pool);
            return pool;
        }

        Debug.Log(id + " pool already exist");
        return null;
    }

   
    public void DestroyPool(PoolType id)
    {
        int IntID = (int) id;
           
        if(_dictionaryPools.ContainsKey(IntID))
        {
            _dictionaryPools.Remove(IntID);
            return;
        }

        Debug.Log(id + " pool already exist");
    }
        
    
    //Get gameObject
    public GameObject Get(PoolType id)
    {
        Pool pool;
        
        if(_dictionaryPools.TryGetValue((int)id, out  pool))
        {
            return pool.Get();
        }
        
        Debug.Log("Pool is not exist");
        return null;
    }

 
    
    public bool IsContaince(PoolType id, GameObject obj)
    {
        return _dictionaryPools[(int) id].Contains(obj);
    }


    public Queue<GameObject> GetStack(PoolType id)
    {
        if (_dictionaryPools.ContainsKey((int) id))
        {
            return _dictionaryPools[(int) id].GetCollection();
        }

        Debug.Log("Pool is not exist");
        return null;
    } 

    public GameObject[] ReSpawn(PoolType id, int count)
    {
        GameObject[] obj = new GameObject[count];
        
        for (int i = 0; i < count; i++)
        {
            obj[i] = _dictionaryPools[(int) id].ReSpawn();
            if (obj[i] == null)
            {
                Debug.LogFormat("Pool {0} is empty.", id);

                if (DynamicPool)
                {
                    obj[i] = Instantiate(_dictionaryPools[(int) id].GetOriginalPrefabe());
                    IPoollable IPoollabl = obj[i].GetComponent<IPoollable>();
                    if(IPoollabl != null) IPoollabl.Init();

                    Debug.LogFormat("Add one object to {0} pool.", id );
                }
            }

            IPoollable iPoollable = obj[i].GetComponent<IPoollable>();
            if(iPoollable != null) iPoollable.ReSpawn();
        }
        
        return obj;
    }


    public GameObject ReSpawn(PoolType id)
    {
        var obj = _dictionaryPools[(int) id].ReSpawn();
        if (obj == null)
        {
            Debug.LogFormat("Pool {0} is empty.", id);

            if (DynamicPool)
            {
                obj = Instantiate(_dictionaryPools[(int) id].GetOriginalPrefabe());
                IPoollable IPoollabl = obj.GetComponent<IPoollable>();
                if(IPoollabl != null) IPoollabl.Init();

                Debug.LogFormat("Add one object to {0} pool.", id );
            }
        }

        IPoollable iPoollable = obj.GetComponent<IPoollable>();
        if(iPoollable != null) iPoollable.ReSpawn();
        
        return obj;
    }



    public void DeSpawn(PoolType id, GameObject obj, bool commonTransform = true, bool setActive = false)
    {
        Pool pool;

        if(_dictionaryPools.TryGetValue((int)id, out pool))
        {
            pool.AddObject(obj, commonTransform);

            var ipoolable = obj.GetComponent<IPoollable>();
            if (ipoolable != null) ipoolable.DeSpawn();

            obj.SetActive(setActive);
        }

        else Debug.LogFormat("{0} pool does not exist", id);
    }


    public void AddObjects(PoolType id, GameObject[] objects)
    {
        Pool pool;

        if (_dictionaryPools.TryGetValue((int) id, out pool))
        {                
            pool.AddObjects(objects, true);
            foreach (var obj in objects)
            {
                IPoollable iPoollable = obj.GetComponent<IPoollable>();
                if(iPoollable != null) iPoollable.Init();   
            }
        }
        else Debug.Log("Pool is not find");
    }
  
    public void AddObject(PoolType id, GameObject obj)
    {
        Pool pool = null;

        if (_dictionaryPools.TryGetValue((int) id, out pool))
        {                
             pool.AddObject(obj, true);
            IPoollable iPoollable = obj.GetComponent<IPoollable>();
            if(iPoollable != null) iPoollable.Init();
        }

        else Debug.Log("Pool is not find");
    }

   
    public void MixObject(PoolType id)
    {
        Pool pool;
        if (_dictionaryPools.TryGetValue((int) id, out pool))
        {
            var arr = GetStack(id).ToArray();
            GetStack(id).Clear();
            System.Random rnd = new System.Random();
            foreach (var value in arr.OrderBy(x => rnd.Next()))
                GetStack(id).Enqueue(value); 
        }
        else Debug.Log(id + " pool not exist");
    }
}



public enum PoolType
{
   Pike,
   Enemy,
   Enemy1,
   Enemy2,
   Enemy3
}
