using UnityEngine;

public class MouseEventHandlerManager : MonoBehaviour
{
    public delegate void OnMouseDownDelegate();
    public static event OnMouseDownDelegate mouseDownEvent;

    public static MouseEventHandlerManager I { get; private set; }

    private void Awake()
    {
        if(I != null && I != this) Destroy(gameObject); I = this;
    }

    public void HandleMouseDownEvent() => mouseDownEvent?.Invoke();
}
