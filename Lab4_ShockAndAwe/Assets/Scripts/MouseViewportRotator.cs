using UnityEngine;

public class MouseViewportRotator : MonoBehaviour
{
    public static MouseViewportRotator Instance { get; private set; }
    public Ray MouseOrientationRay { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    void Update()
    {
        var x = Mathf.Clamp01(Utils.Mathf.Map(Input.mousePosition.x, 0, Screen.width, 0, 1));
        var y = Mathf.Clamp01(Utils.Mathf.Map(Input.mousePosition.y, 0, Screen.height, 0, 1));
        MouseOrientationRay = Camera.main.ViewportPointToRay(new Vector3(x, y, 0));
    }
}
