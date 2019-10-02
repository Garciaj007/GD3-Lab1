using UnityEngine;

public class PlayerMovementState : StateMachineBehaviour
{
    private GameObject gameObject;

    private Rigidbody2D body;

    private PlayerEntity playerEntity;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get GameObject
        gameObject = animator.gameObject;
        // Get Rigidbody2D
        body = gameObject.GetComponent<Rigidbody2D>();
        // Get PlayerEntity
        playerEntity = gameObject.GetComponent<PlayerComponent>().Sciptable;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get axis
        float verticalAxis      = Input.GetAxis("Vertical");
        float horizontalAxis    = -Input.GetAxis("Horizontal");

        // Forbid going back
        verticalAxis = verticalAxis > 0f ? verticalAxis : 0f;

        // Movement
        
        // Limit angle
        if (Mathf.Abs(body.angularVelocity) < playerEntity.MaxRotateAngle)
            body.AddTorque(horizontalAxis * playerEntity.rotationAmount);

        body.AddRelativeForce(Vector2.up * verticalAxis * playerEntity.movementSpeed);
    }
}
