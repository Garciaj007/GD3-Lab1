using UnityEngine;

public class UniformScaleToViewport : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = 
            new Vector3(Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height * 2, 
            Camera.main.orthographicSize * 2);
    }
}
