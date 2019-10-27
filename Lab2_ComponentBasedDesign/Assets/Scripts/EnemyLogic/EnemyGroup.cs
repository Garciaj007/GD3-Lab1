using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{

    [SerializeField] private GameObject enemyObj = null;
    public static int SpawnSize { get; set; } = 6;
    public Dictionary<int, Vector2> Enemies { get; private set; }
    public void Awake()
    {
        Enemies = new Dictionary<int, Vector2>();
    }

    public void Start()
    {
        for (var i = SpawnSize; i > 0; i--)
        {
            var spawnPosition = transform.position.XY() + Random.insideUnitCircle * 2.0f;
            Instantiate(enemyObj, new Vector3(spawnPosition.x, spawnPosition.y), Quaternion.identity, transform);
        }
    }

    public void Add(int id, Vector2 position)
    {
        Enemies.Add(id, position);
    }
    public void Remove(EnemyController controller)
    {
        Enemies.Remove(controller.Id);
    }
    public void DestroyAll()
    {
        Enemies.Clear();
    }
}
