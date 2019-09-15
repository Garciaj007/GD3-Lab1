using UnityEngine;

public class Scaler2D : MonoBehaviour
{
    [SerializeField] private Vector2 speed = new Vector2(1,1);

    private BlockAccelerator blockAccelerator;
    private BeatScaler2D beatScaler2D;

    private void Start()
    {
        blockAccelerator = GetComponent<BlockAccelerator>();
        beatScaler2D = GetComponent<BeatScaler2D>();
    }

    void Update()
    {
        var accel = blockAccelerator.Accelerator;
        transform.localScale += new Vector3(speed.x * Time.deltaTime * accel,
                                            speed.y * Time.deltaTime * accel, 0);
    }
}
