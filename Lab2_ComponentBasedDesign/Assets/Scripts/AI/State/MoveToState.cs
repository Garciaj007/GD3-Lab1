using UnityEngine;

public class MoveToState : StateMachineBehaviour
{
    private GameObject gameObject;

    private LaneAgentData laneAgentData;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObject = animator.gameObject;

        laneAgentData = gameObject.GetComponent<LaneAgentData>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (laneAgentData.lastPoint == null)
        {
            laneAgentData.SiwtchLastPoint(0);
        }

        // Check distance
        if (Vector3.Distance(laneAgentData.lastPoint.transform.position, gameObject.transform.position) < 0.1f)
        {
            laneAgentData.SiwtchLastPoint(laneAgentData.pointIndex + 1);
        }

        // Move
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, laneAgentData.lastPoint.transform.position, 3f * Time.deltaTime);
    }
}
