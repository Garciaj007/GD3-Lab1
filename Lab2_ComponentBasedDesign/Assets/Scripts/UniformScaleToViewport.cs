using UnityEngine;

public class UniformScaleToViewport : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3(Screen.width, Screen.width);
    }
}
