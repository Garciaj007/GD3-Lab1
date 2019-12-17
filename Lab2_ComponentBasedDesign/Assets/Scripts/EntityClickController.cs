using UnityEngine;

public class EntityClickController : MonoBehaviour {

    [SerializeField] private Color restColor = Color.white;
    [SerializeField] private Color hoverColor = Color.white;
    [SerializeField] private Color downColor = Color.white;

    private SpriteRenderer sp = null;

    private void Start () => sp = GetComponent<SpriteRenderer>();
    private void OnMouseEnter() => sp.color = hoverColor;
    private void OnMouseExit() => sp.color = restColor;
    private void OnMouseUp() => sp.color = hoverColor;
    private void OnMouseDown() { GameManager.Instance.DispatchEntity(gameObject); sp.color = downColor; }
}
