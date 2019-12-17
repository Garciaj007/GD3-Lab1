using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector2 dimensions = Vector2.zero;
    [SerializeField] private GameObject enemyGroup = null;

    private Utils.Timer spawnTimer = new Utils.Timer(5.0f);

    private void Start()
    {
        spawnTimer.TimerFinished += SpawnEnemy;
        spawnTimer.Start();
        SpawnEnemy();
    }

    private void Update() => spawnTimer.Update();

    private void SpawnEnemy()
    {
        Vector2 position;
        if (Random.Range(0, 2) == 0)
            position = new Vector2(Random.Range(-dimensions.x, dimensions.x), Random.Range(0, 2) == 0 ? -dimensions.y : dimensions.y);
        else
            position = new Vector2(Random.Range(0, 2) == 0 ? -dimensions.x : dimensions.x, Random.Range(-dimensions.y, dimensions.y));

        Instantiate(enemyGroup, new Vector3(position.x, position.y), Quaternion.identity, GameObject.Find("Enemies").transform);
    }
}
