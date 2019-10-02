using UnityEngine;

public class PlayerMovementState : StateMachineBehaviour
{
    private GameObject gameObject;

    private Rigidbody2D body;

    private Entity playerEntity;

    private Vector3 point;
    Quaternion rot;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get GameObject
        gameObject = animator.gameObject;
        // Get Rigidbody2D
        body = gameObject.GetComponent<Rigidbody2D>();
        // Get PlayerEntity
        playerEntity = gameObject.GetComponent<EntityComponent>().Entity;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetMouseButtonDown(0))
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 1f;

            var direction = (point - gameObject.transform.position);

            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rot = Quaternion.AngleAxis(-angle, Vector3.forward);
        }

        // Movement
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, point, playerEntity.movementSpeed * Time.deltaTime);
        gameObject.transform.rotation =
            Quaternion.Slerp(gameObject.transform.rotation, rot, Time.deltaTime * playerEntity.rotationAmount);
    }
}
