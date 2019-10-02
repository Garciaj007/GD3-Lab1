using UnityEngine;

public class MotionBlurCapture : MonoBehaviour
{
    private Camera renderCamera;

    private void Awake()
    {
        renderCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        renderCamera.targetTexture.width = Screen.width;
        renderCamera.targetTexture.height = Screen.height;

        renderCamera.orthographicSize = renderCamera.orthographicSize;
    }
}
