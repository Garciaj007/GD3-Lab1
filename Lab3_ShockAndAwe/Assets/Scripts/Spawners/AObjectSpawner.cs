using UnityEngine;

public abstract class AObjectSpawner : MonoBehaviour
{
    protected ObjectPool objectPool = null;
    protected new string name;

    private void Awake()
    {
        objectPool = ObjectPool.Instance;    
    }

    protected abstract void Spawn();
}
