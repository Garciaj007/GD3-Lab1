using UnityEngine;
public class EnemyController : MonoBehaviour
{
    private static int _enemyId = 0;

    public static float wanderRadius = 4.0f;
    public static float desiredSeparation = 1.0f;
    public static float neighborDistance = 2.0f;
    public static int EnemyId => ++_enemyId;
    public int Id { get; private set; }

    public EnemyGroup group = null;
    private void Awake()
    {
        Id = EnemyId;
        @group = transform.parent.GetComponent<EnemyGroup>();
        @group.Add(Id, transform.position);
        GetComponent<HealthComponent>().DeathDelegate += KillEnemy;
    }

    private void KillEnemy()
    {
        GetComponent<Animator>().SetTrigger("OnDeath");
        @group.Remove(this);
        GetComponent<HealthComponent>().DeathDelegate -= KillEnemy;
    }
}

