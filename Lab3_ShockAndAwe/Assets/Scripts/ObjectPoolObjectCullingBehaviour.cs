using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolObjectCullingBehaviour : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void FixedUpdate()
    {
        if(transform.position.z < gm.CullAndDepth.x || transform.position.z > gm.CullAndDepth.y)
            gameObject.SetActive(false);
    }
}
