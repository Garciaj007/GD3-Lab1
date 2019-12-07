using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : AObjectSpawner
{
    [System.Serializable]
    public class TargetData
    {
        public string name;
        public int minSpawnCount;
        public int maxSpawnCount;
    }

    [SerializeField] protected Vector2 dimensions;
    [SerializeField] protected List<TargetData> targets;

    private int count = 0;

    private void Update()
    {
        if (BeatSequencer.Instance.BeatFull)
        {
            var target = targets[count];
            
            name = target.name;

            for(int i = 0; i < Random.Range(target.minSpawnCount, target.maxSpawnCount); i++)
                Spawn();

            ++count;
            count = count > targets.Count - 1 ? 0 : count < 0 ? targets.Count - 1 : count;
        }
    }

    protected override void Spawn()
    {
        var spawnPos = new Vector3(Random.Range(-dimensions.x, dimensions.x),
            Random.Range(-dimensions.y, dimensions.y), GameManager.Instance.CullAndDepth.y);
        objectPool.SpawnFromPool(name, spawnPos, Quaternion.Euler(Vector3.back));
    }
}
