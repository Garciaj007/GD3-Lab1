using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveToPosState : StateMachineBehaviour
{
    private GameObject gameObject;
    private PlayerController controller;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObject = animator.gameObject;
        controller = gameObject.GetComponent<PlayerController>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If too close
        if (Vector3.Distance(gameObject.transform.position, controller.moveToPos) < .01f)
        {
            animator.SetBool("Idle", true);
        }

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, controller.moveToPos, controller.Speed * Time.deltaTime);

        Vector3 direction = controller.moveToPos - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, q, Time.deltaTime * controller.Speed);
    }

    public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Chase", false);
    }
}
