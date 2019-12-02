using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class PoolData
    {
        public string name;
        public GameObject prefab;
        public int size;
    }

    public List<PoolData> poolData;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    public static ObjectPool Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (PoolData pool in poolData)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                var obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.name, objectPool);
        }

    }

    public GameObject SpawnFromPool(string name, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(name)) return null;

        var spawnObj = poolDictionary[name].Dequeue();

        spawnObj.GetComponent<IPooledObject>()?.OnObjectHide();
        spawnObj.SetActive(true);
        spawnObj.transform.position = position;
        spawnObj.transform.rotation = rotation;
        spawnObj.GetComponent<IPooledObject>()?.OnObjectSpawned();

        poolDictionary[name].Enqueue(spawnObj);

        return spawnObj;
    }
}
