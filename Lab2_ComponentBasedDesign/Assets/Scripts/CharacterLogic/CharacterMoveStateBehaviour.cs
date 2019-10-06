using UnityEngine;

public class CharacterMoveStateBehaviour : StateMachineBehaviour
{
    private GameObject characterAttached = null;
    private Rigidbody2D rigid = null;
    private Entity entity = null;

    public Vector2 NewPosition { get; set; } = Vector2.zero;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterAttached = animator.gameObject;
        rigid = characterAttached.GetComponent<Rigidbody2D>();
        entity = characterAttached.GetComponent<EntityComponent>().Entity;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Find Desired Vector to Click Point
        var desired = NewPosition - characterAttached.transform.position.XY();

        //Stop Moving if Character Is Near a Certain Range
        if (desired.magnitude < 0.1f)
        {
            animator.SetBool("Moving", false);
            return;
        }

        //Limit Character Speed to Max/Ariving Velocity
        if (desired.magnitude < entity.arrivingDistance)
            desired = desired.normalized * 
                Utils.Mathf.Map(desired.magnitude, 0, entity.arrivingDistance, 0, entity.maxSpeed);
        else
            desired = desired.normalized * entity.maxSpeed;

        //Steering Behaviour
        var steer = desired - rigid.velocity;
        steer = Vector2.ClampMagnitude(steer, entity.maxForce);

        rigid.AddForce(steer);

        //Rotation Behaviour
        float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        characterAttached.transform.rotation = Quaternion.Slerp(characterAttached.transform.rotation, q, Time.deltaTime * entity.maxSpeed);
    }
}
