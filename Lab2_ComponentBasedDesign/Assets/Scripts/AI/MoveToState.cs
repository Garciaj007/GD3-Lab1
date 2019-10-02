using UnityEngine;

public class MoveToState : StateMachineBehaviour
{
    private GameObject gameObject;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObject = animator.gameObject;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
