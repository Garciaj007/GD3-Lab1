using UnityEngine;

public class OrientationFromRigidbody2DVelocity : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rigid = null;

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.sqrMagnitude > 0)
            transform.up = rigid.velocity;
    }
}
