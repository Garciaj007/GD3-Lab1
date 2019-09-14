using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVector2VerticalBoundsTranslate : ControlComponent
{
    [Header("Properties")]
    [SerializeField] private float speed;
    [SerializeField] private float pushbackSpeed;
    [Header("Data Node")]
    [SerializeField] private string nodeName = "playerInput";

    private SpriteMask mask;
    private Rigidbody2D rigid; 
    private DataNode cachedVector;
    public override void Gather(Data data)
    {
        cachedVector = data[nodeName];
        mask = GetComponent<SpriteMask>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public override void Execute()
    {
        var newPos = new Vector3(0, ((Vector2)cachedVector).y * speed);

        if(mask.bounds.extents.y + transform.position.y > 
                Camera.main.orthographicSize )
        {
            newPos = Vector3.down * pushbackSpeed;
        }
        else if(-mask.bounds.extents.y + transform.position.y <
                -Camera.main.orthographicSize )
        {
            newPos = Vector3.up * pushbackSpeed;
        }

        rigid.AddForce(newPos);
    }
}
