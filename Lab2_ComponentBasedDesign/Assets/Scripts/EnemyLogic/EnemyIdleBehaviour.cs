using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyIdleBehaviour : StateMachineBehaviour
{
    private EnemyController enemyAttached = null;
    private Entity entity = null;
    private Rigidbody2D rigid = null;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyAttached = animator.gameObject.GetComponent<EnemyController>();
        rigid = enemyAttached.GetComponent<Rigidbody2D>();
        entity = enemyAttached.GetComponent<EntityComponent>().Entity;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyAttached.@group == null) return;
        rigid.AddForce(Separate(enemyAttached.@group.Enemies));
        rigid.AddForce(Align(enemyAttached.@group.Enemies));
        rigid.AddForce(Cohesion(enemyAttached.@group.Enemies));
        rigid.AddForce(Center(enemyAttached.@group.Enemies));

        var angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, q, Time.deltaTime * entity.maxSpeed);
    }
    private Vector2 Separate(Dictionary<int, Vector2> group)
    {
        var steer = Vector2.zero;
        var count = 0;

        foreach (var pair in group)
        {
            if(pair.Key == enemyAttached.Id) continue;

            var d = Vector2.Distance(group[enemyAttached.Id], pair.Value);
            if ((!(d > 0)) || (!(d < EnemyController.desiredSeparation))) continue;

            var diff = (group[enemyAttached.Id] - pair.Value).normalized;
            steer += diff / d;
            count++;
        }

        if (count > 0) steer /= count;

        if (!(steer.magnitude > 0)) return steer;

        steer = entity.maxSpeed * steer.normalized;
        steer -= rigid.velocity;

        return steer.magnitude > entity.maxForce ? steer.normalized * entity.maxForce : steer;
    }

    private Vector2 Align(Dictionary<int, Vector2> group)
    {
        var sum = Vector2.zero;
        var steer = Vector2.zero;
        var count = 0;

        foreach (var pair in from pair in @group where pair.Key != enemyAttached.Id let d = Vector2.Distance(@group[enemyAttached.Id], pair.Value) where (d > 0) && (d < EnemyController.neighborDistance) select pair)
        {
            sum += pair.Value;
            count++;
        }

        if (count <= 0) return steer;
        sum = sum.normalized * entity.maxSpeed;
        steer = sum - rigid.velocity;
        steer = steer.magnitude > entity.maxForce ? steer.normalized * entity.maxForce : steer;

        return steer;
    }
    private Vector2 Cohesion(Dictionary<int, Vector2> group)
    {
        var sum = Vector2.zero;
        var count = 0;

        foreach (var pair in from pair in @group where pair.Key != enemyAttached.Id let d = Vector2.Distance(@group[enemyAttached.Id], pair.Value) where (d > 0) && (d < EnemyController.neighborDistance) select pair)
        {
            sum += pair.Value;
            count++;
        }

        if (count <= 0) return Vector2.zero;

        sum /= count;
        var desired = (sum - @group[enemyAttached.Id]).normalized / entity.maxSpeed;
        var steer = desired - rigid.velocity;
        return steer.magnitude > entity.maxForce ? steer.normalized * entity.maxForce : steer;
    }

    private Vector2 Center(Dictionary<int, Vector2> group)
    {
        if (group[enemyAttached.Id].magnitude < EnemyController.wanderRadius) return Vector2.zero;
        var desired = enemyAttached.transform.parent.position.XY() - rigid.velocity;
        var steer = desired.normalized * entity.maxSpeed;
        return steer.magnitude > entity.maxForce ? steer.normalized * entity.maxForce : steer;
    }
}
