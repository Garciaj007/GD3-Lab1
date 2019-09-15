using UnityEngine;

public class ApplyBeatScaler : MonoBehaviour
{
    [SerializeField] private Vector3 scaleDirection = Vector3.one;
    void Update()
    {
        transform.localScale = scaleDirection * BeatScaler2D.Instance.Scale;
    }
}
