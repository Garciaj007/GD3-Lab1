using UnityEngine;

public class ClickableBehaviour : MonoBehaviour
{
    [SerializeField] private Color hoverColor = Color.white;
    [SerializeField] private Color restColor = Color.white;
    [SerializeField] private Color downColor = Color.white;

    private SpriteRenderer sp = null;

    public void Start()
    {
        MouseEventHandlerManager.mouseDownEvent += DownState;
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy() => MouseEventHandlerManager.mouseDownEvent -= DownState;
    private void OnMouseUp() => sp.color = restColor;
    private void OnMouseEnter() => sp.color = hoverColor;
    private void OnMouseExit() => sp.color = restColor;
    private void OnMouseDown() => MouseEventHandlerManager.I.HandleMouseDownEvent();
    private void DownState() => sp.color = downColor;
}
