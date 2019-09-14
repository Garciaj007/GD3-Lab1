using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    void Update()
    {
        transform.Translate(transform.up.normalized * speed * Time.deltaTime, Space.World);
    }
}
