using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;

    private BlockAccelerator blockAccelerator;
    private void Start()
    {
        blockAccelerator = GetComponent<BlockAccelerator>();
    }

    void Update()
    {
        transform.Translate(transform.up.normalized * speed * Time.deltaTime * blockAccelerator.Accelerator, 
            Space.World);
    }
}
