using UnityEngine;

[RequireComponent (typeof(PolygonCollider2D))]
public class EntityClickController : MonoBehaviour {

    public delegate void OnCharacterClickDelegate(GameObject gameObject_);
    public static event OnCharacterClickDelegate onCharacterClick;

    void OnMouseDown() {
        if (onCharacterClick != null) onCharacterClick(this.gameObject);
    }
}
