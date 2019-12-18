using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public static float wanderRadius = 1.0f;
    private static int targetId = 0;
    public static int TargetId => ++targetId;

    public EnemyGroup group;
    public int Id { get; private set; }

    private Animator animator;
    private Utils.Timer toggleStateTimer = new Utils.Timer(4.0f);

    private void Awake()
    {
        Id = TargetId;
        group = transform.parent.GetComponent<EnemyGroup>();
        group.Add(Id, transform.parent.position.XY() + Random.insideUnitCircle.normalized * wanderRadius);
        GetComponent<HealthComponent>().DeathDelegate += KillEnemy;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        toggleStateTimer.TimerFinished += ToggleState;
        toggleStateTimer.Start();
    }

    private void Update()
    {
        toggleStateTimer.Update();

        var playerDistance = 10000.0f;
        foreach(var playerController in GameManager.Instance.Players)
        {
            var distance = (playerController.transform.position - transform.position).magnitude;
            playerDistance = distance < playerDistance ? distance : playerDistance;
        }

        animator.SetFloat("PlayerDistance", playerDistance);
    }

    private void OnDestroy() => GetComponent<HealthComponent>().DeathDelegate -= KillEnemy;

    private void ToggleState() => animator.SetBool("Attack", !animator.GetBool("Attack"));

    private void KillEnemy()
    {
        group.Remove(this);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("CoreUnit")) return;
        collision.GetComponent<HealthComponent>().Damage(1.0f);
        KillEnemy();        
    }
}

