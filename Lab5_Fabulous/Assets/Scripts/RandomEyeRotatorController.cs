using UnityEngine;

public class RandomEyeRotatorController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private float angle = 0f;

    private void Start() => speed *= Random.Range(0, 2) == 0 ? -1.0f : 1.0f;

    private void Update()
    {
        angle += speed * Mathf.Deg2Rad * Time.deltaTime;
        transform.Rotate(Vector3.forward, angle);
    }
}
