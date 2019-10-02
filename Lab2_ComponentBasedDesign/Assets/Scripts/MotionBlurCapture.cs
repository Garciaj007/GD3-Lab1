using UnityEngine;

public class MotionBlurCapture : MonoBehaviour
{
    [SerializeField] private Camera renderCamera;

    private void Awake()
    {
        if (renderCamera.targetTexture != null)
            renderCamera.targetTexture.Release();

        renderCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 10);
    }
}
