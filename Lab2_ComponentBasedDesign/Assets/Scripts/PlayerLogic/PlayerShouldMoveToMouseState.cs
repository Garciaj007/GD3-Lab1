using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShouldMoveToMouseState : StateMachineBehaviour
{
    private PlayerController controller;
    private Animator ani;

    public override void OnStateEnter(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.gameObject.GetComponent<PlayerController>();
        ani = animator;

        controller.OnMouseDownPos += MoveToPos;
    }

    public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.OnMouseDownPos -= MoveToPos;
    }

    private void MoveToPos(Vector3 pos)
    {
        controller.moveToPos = pos;
        ani.SetBool("Chase", true);
    }
}
