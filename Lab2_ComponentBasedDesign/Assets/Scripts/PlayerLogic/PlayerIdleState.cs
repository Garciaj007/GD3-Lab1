using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : StateMachineBehaviour
{
    private PlayerController controller;

    public override void OnStateEnter(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.gameObject.GetComponent<PlayerController>();
        controller.OnTrigger2DEnter += OnPlayerTrigger2DEnter;
    }

    public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.OnTrigger2DEnter -= OnPlayerTrigger2DEnter;
    }

    private void OnPlayerTrigger2DEnter(Collider2D info)
    {
        if (info.tag == "EnemyUnit")
        {
            Debug.Log("Enemy unit detected!");
        }
    }
}
