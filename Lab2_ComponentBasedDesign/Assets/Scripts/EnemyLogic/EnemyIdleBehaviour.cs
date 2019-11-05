using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyIdleBehaviour : StateMachineBehaviour
{
    public static float arrivingDistance = 0.1f;
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

        var target = enemyAttached.@group.Targets[enemyAttached.Id];
        Seek(ref target);
        enemyAttached.@group.Targets[enemyAttached.Id] = target;

        var angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, q, Time.deltaTime * entity.maxSpeed);
    }

    private void Seek(ref Vector2 target)
    {
        var desired = target - rigid.position;
        var distance = desired.magnitude;

        if (distance < arrivingDistance)
        {
            for (var i = 0; i < 10; i++)
            {
                target = rigid.transform.parent.position.XY() + (Random.insideUnitCircle.normalized * EnemyController.wanderRadius);
                if ((target - rigid.position).magnitude > arrivingDistance) return;
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
