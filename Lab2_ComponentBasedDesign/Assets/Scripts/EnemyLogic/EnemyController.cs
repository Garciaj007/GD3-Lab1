using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public static float wanderRadius = 1.0f;

    private static int targetId = 0;
    public static int TargetId => ++targetId;
    public int Id { get; private set; }

    private Animator animator;

    public EnemyGroup group;

    private void Awake()
    {
        Id = TargetId;
        @group = transform.parent.GetComponent<EnemyGroup>();
        @group.Add(Id, transform.parent.position.XY() + Random.insideUnitCircle.normalized * wanderRadius);
        GetComponent<HealthComponent>().DeathDelegate += KillEnemy;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var playerDistance = 10000.0f;

        foreach(var playerController in GameManager.Instance.Players)
        {
            var distance = (playerController.transform.position - transform.position).magnitude;
            playerDistance = distance < playerDistance ? distance : playerDistance;
        }

        animator.SetFloat("PlayerDistance", playerDistance);
    }

    private void KillEnemy()
    {
        GetComponent<Animator>().SetTrigger("OnDeath");
        @group.Remove(this);
        GetComponent<HealthComponent>().DeathDelegate -= KillEnemy;
    }
}

