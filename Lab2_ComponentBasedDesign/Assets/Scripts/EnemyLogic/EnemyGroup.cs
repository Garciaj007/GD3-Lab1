using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private GameObject enemyObj = null;
    public static int SpawnSize { get; set; } = 50;
    public Dictionary<int, Vector2> Targets { get; private set; } = new Dictionary<int, Vector2>();

    public void Start()
    {
        for (var i = SpawnSize; i > 0; i--)
        {
            var spawnPosition = Random.insideUnitCircle * EnemyController.wanderRadius;
            Instantiate(enemyObj, new Vector2(spawnPosition.x, spawnPosition.y) + transform.position.XY(), Quaternion.identity, transform);
        }
    }

    public void Add(int id, Vector2 position)
    {
        Targets.Add(id, position);
    }
    public void Remove(EnemyController controller)
    {
        Targets.Remove(controller.Id);
        if(Targets.Count <= 0) Destroy(gameObject);
    }
    public void OnDestroy()
    {
        Targets.Clear();
    }
}
