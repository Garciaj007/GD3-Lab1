using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingBoundriesBehaviour : MonoBehaviour
{
    GameManager gm;

    private void Start() => gm = GameManager.Instance;

    private void Update()
    {
        if(transform.position.z < gm.CullAndDepth.x || transform.position.z > gm.CullAndDepth.y)
            GetComponent<IPooledObject>()?.OnObjectHide();
    }
}
