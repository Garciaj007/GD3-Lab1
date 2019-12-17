using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static float ClickMinRadius = 2.0f;

    [SerializeField] private PlayerController player;

    private EntityComponent entity = null;
    private Animator anim = null;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        entity = GetComponent<EntityComponent>();
        player.NewPositionClick += HandleNewPositionClick;
    }

    private void OnDestroy()
    {
        player.NewPositionClick -= HandleNewPositionClick;
    }
    private void Update() => anim.SetBool("DefenseMode", entity.InDefense);

    void HandleNewPositionClick (Vector3 mousePos)
    {
        if (GameManager.Instance.CurrentSelected != gameObject) return;
        if ((mousePos.XY() - gameObject.transform.position.XY()).magnitude < ClickMinRadius) return;
        anim.GetBehaviour<CharacterMoveStateBehaviour>().NewPosition = mousePos;
        anim.SetBool("Moving", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(entity.CanMove) return;

        if(collision.CompareTag("EnemyUnit"))
            collision.gameObject.GetComponent<HealthComponent>().Damage(entity != null ? entity.Entity.attackDamage : 1.0f);
    }
}
