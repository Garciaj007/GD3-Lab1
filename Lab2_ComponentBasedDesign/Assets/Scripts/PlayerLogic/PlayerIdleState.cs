using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : StateMachineBehaviour
{
    private PlayerController controller;
    private Animator ani;

    public override void OnStateEnter(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.gameObject.GetComponent<PlayerController>();
        controller.OnTrigger2DStay += OnPlayerTrigger2DEnter;

        ani = animator;

        animator.SetBool("Idle", true);
    }

    public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.OnTrigger2DStay -= OnPlayerTrigger2DEnter;

        animator.SetBool("Idle", false);
    }

    private void OnPlayerTrigger2DEnter(Collider2D info)
    {
        if (info.tag == "EnemyUnit")
        {
            // If too close
            if (Vector3.Distance(info.transform.position, controller.moveToPos) < .01f)
            {
                // Attack
                ani.SetBool("Attack", true);
            }
            else
            {
                Debug.Log("Enemy unit detected!");

                controller.moveToPos = info.transform.position;
                ani.SetBool("Chase", true);
            }
        }
    }
}
