using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVector2RadialTranslate : ControlComponent
{
    [Header("Properties")]
    [SerializeField] private float radius = 2;
    [SerializeField] private float angularSpeed = 1;
    [SerializeField] private float angularPosition = 0;
    [Header("Data Node")]
    [SerializeField] private string nodeName = "inputVector2";

    private DataNode cachedVector;

    public override void Gather(Data data)
    {
        cachedVector = data[nodeName];
    }

    public override void Execute()
    {
        angularPosition += ((Vector2)cachedVector).x * angularSpeed;
        transform.position = new Vector2(radius * Mathf.Sin(angularPosition), radius * Mathf.Cos(angularPosition));
    }
}
