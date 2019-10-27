using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MoveToStateEvent : UnityEvent<MoveToState> { }

public class MoveToState : StateMachineBehaviour
{
    public MoveToStateEvent PosVecEvent;
    public float Speed;

    public string SuccessKey;

    internal Vector3 target;

    internal GameObject gameObject;
    private Rigidbody2D body;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObject = animator.gameObject;
        body = gameObject.GetComponent<Rigidbody2D>();

        PosVecEvent.Invoke(this);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If too close
        if (Vector3.Distance(gameObject.transform.position, target) < 1f)
        {
            animator.SetBool(SuccessKey, true);
        }

        var direction = Vector3.zero;
        direction = target - gameObject.transform.position;
        body.AddRelativeForce(direction.normalized * Speed, ForceMode2D.Force);
    }
}
