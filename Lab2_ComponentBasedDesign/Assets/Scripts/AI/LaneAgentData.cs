using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneAgentData : MonoBehaviour
{
    public GameObject PointPacks;
    private List<GameObject> points;

    // Last point AI used
    internal GameObject lastPoint;
    internal int pointIndex;

    private void Start()
    {
        lastPoint = null;
        pointIndex = 0;

        points = new List<GameObject>(PointPacks.transform.childCount);

        // Add all points
        for (int i = 0; i < PointPacks.transform.childCount; i++)
        {
            var child = PointPacks.transform.GetChild(i).gameObject;
            points.Add(child);
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1f);
    }

    internal void SiwtchLastPoint(int index)
    {
        if (index >= points.Count) return;

        pointIndex = index;
        lastPoint = points[index];
    }
}