using UnityEngine;

public class HidePooledObject : MonoBehaviour, IPooledObject
{
    public void OnObjectHide() => gameObject.SetActive(false);
    public void OnObjectSpawned() { }
}
