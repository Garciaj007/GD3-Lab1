using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Translate(transform.up.normalized * speed * Time.deltaTime, Space.World);
    }
}
