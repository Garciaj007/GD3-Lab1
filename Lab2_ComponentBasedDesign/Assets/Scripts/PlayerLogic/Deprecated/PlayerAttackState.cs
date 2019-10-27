using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : StateMachineBehaviour
{
    private PlayerController controller;

    private float timer = 0;

    public override void OnStateEnter(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.gameObject.GetComponent<PlayerController>();

        timer = 0;
    }

    public override void OnStateUpdate(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        //if (timer > controller.AttackCoolDown)
        //{
        //    animator.SetBool("Idle", true);
        //}
    }

    public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
        
    }
}
