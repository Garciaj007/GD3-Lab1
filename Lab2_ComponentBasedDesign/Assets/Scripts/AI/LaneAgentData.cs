using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneAgentData : MonoBehaviour
{
    private void Start()
    {
    }

    public void GetPlayerPos(MoveToState state)
    {
        Vector3 pos = Vector3.zero;
        if (GlobalGameData.Instance.GetRandomPlayerPosition(out pos))
        {
            var newPos = (state.gameObject.transform.position - pos).normalized;
            newPos *= 100f;

            state.target = -newPos;
        }
        else
        {
            state.target = Vector3.zero;
        }
    }

    public void GetRandomPos(MoveToState state)
    {
        state.target = GlobalGameData.Instance.GetRandomCamPosition();
    }
}