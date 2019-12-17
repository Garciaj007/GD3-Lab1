using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : StateMachineBehaviour
{
    public static float arrivingRadius = 0.5f;

    private EnemyController enemyAttached;
    private Entity entity;
    private Rigidbody2D rigid;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyAttached = animator.gameObject.GetComponent<EnemyController>();
        rigid = enemyAttached.GetComponent<Rigidbody2D>();
        entity = enemyAttached.GetComponent<EntityComponent>().Entity;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyAttached.@group == null) return;

        var target = Vector2.zero;
        Seek(ref target);

        var angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, q, Time.deltaTime * entity.maxForce);
    }

    private void Seek(ref Vector2 target)
    {
        var desired = target - rigid.position;
        var distance = desired.magnitude;

        if (distance < entity.arrivingDistance)
        {
            for (var i = 0; i < 10; i++)
            {
                target = rigid.transform.parent.position.XY() + (Random.insideUnitCircle.normalized * EnemyController.wanderRadius * BeatScalar.Instance.Scalar);
                if ((target - rigid.position).magnitude > entity.arrivingDistance) return;
            }
        }

        if (distance < arrivingRadius)
            desired = desired.normalized * Utils.Mathf.Map(distance, arrivingRadius, 0, entity.maxSpeed, 0);
        else
            desired = desired.normalized * entity.maxSpeed;

        var steer = desired - rigid.velocity;
        steer = steer.magnitude > entity.maxForce ? steer.normalized * entity.maxForce : steer;
        rigid.AddForce(steer);
    }
}
