using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBeatScalarToRotation : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float rotationBase = 1f;
    [Range(0f, 20f)]
    [SerializeField] private float rotationMultiplier = 1f;

    [SerializeField] private int count = 0;
    void Update()
    {
        if (BeatSequencer.Instance.BeatFull && DifficultyManager.Instance.Difficulty > 1.3f)
            if (Random.Range(0, 2) == 0) count++;

        if(count > 10)
        {
            rotationBase = -rotationBase;
            count = 0;
        }

        transform.Rotate(0, 0, rotationBase * Mathf.Pow(BeatScalar.Instance.Scalar, rotationMultiplier * DifficultyManager.Instance.Difficulty));    
    }
}
