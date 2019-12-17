using UnityEngine;

public class EntityClickController : MonoBehaviour {
    void OnMouseDown() => GameManager.Instance.DispatchEntity(gameObject);
}
