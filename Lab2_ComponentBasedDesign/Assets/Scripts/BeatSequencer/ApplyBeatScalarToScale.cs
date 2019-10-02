using UnityEngine;

public class ApplyBeatScalarToScale : MonoBehaviour
{
    [SerializeField] private Vector3 scale = Vector3.one;
    [SerializeField] private Vector3 affectScale = Vector3.one;
    void Update()
    {
        transform.localScale = new Vector3(scale.x * (affectScale.x == 0 ? 1 : BeatScalar.Instance.Scalar), 
            scale.y * (affectScale.y == 0 ? 1 : BeatScalar.Instance.Scalar),
            scale.z * (affectScale.z == 0 ? 1 : BeatScalar.Instance.Scalar));
    }
}
