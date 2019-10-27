using UnityEngine;

public class MotionBlurCapture : MonoBehaviour
{
    private Camera renderCamera;

    private void Awake()
    {
        renderCamera = GetComponent<Camera>();
        renderCamera.targetTexture.width = Screen.width;
        renderCamera.targetTexture.height = Screen.height;
        renderCamera.orthographicSize = renderCamera.orthographicSize;
    }
}
