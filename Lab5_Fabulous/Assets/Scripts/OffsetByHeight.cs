using UnityEngine;

public class OffsetByHeight : MonoBehaviour
{
    [SerializeField] private Camera cam = null;
    void Start() =>
        transform.position = new Vector3(transform.position.x, cam.orthographicSize, transform.position.z);
    
}
