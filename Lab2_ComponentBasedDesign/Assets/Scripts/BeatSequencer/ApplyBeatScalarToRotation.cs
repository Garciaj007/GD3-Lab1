using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBeatScalarToRotation : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float rotationBase = 1f;
    [Range(0f, 100f)]
    [SerializeField] private float rotationMultiplier = 1f;

    void Update()
    {
        transform.Rotate(0, 0, rotationBase * Mathf.Pow(BeatScalar.Instance.Scalar, rotationMultiplier));    
    }
}
