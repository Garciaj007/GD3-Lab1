using UnityEngine;
public class EnemyController : MonoBehaviour
{
    private static int _enemyId = 0;

    public static float wanderRadius = 2.0f;
    public static float desiredSeparation = 0.1f;
    public static float neighborDistance = 0.2f;
    public static int EnemyId => ++_enemyId;
    public int Id { get; private set; }

    private Animator animator;

    public EnemyGroup group = null;
    private void Awake()
    {
        Id = EnemyId;
        @group = transform.parent.GetComponent<EnemyGroup>();
        @group.Add(Id, transform.position);
        GetComponent<HealthComponent>().DeathDelegate += KillEnemy;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float playerDistance = 10000.0f;
        foreach(var playerController in GameManager.Instance.Players)
        {
            var distance = (playerController.transform.position - transform.position).magnitude;
            playerDistance = distance < playerDistance ? distance : playerDistance;
        }

        Debug.Log(playerDistance);

        animator.SetFloat("PlayerDistance", playerDistance);
    }

    private void KillEnemy()
    {
        GetComponent<Animator>().SetTrigger("OnDeath");
        @group.Remove(this);
        GetComponent<HealthComponent>().DeathDelegate -= KillEnemy;
    }
}

