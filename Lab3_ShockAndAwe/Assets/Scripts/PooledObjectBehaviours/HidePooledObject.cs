using UnityEngine;

public class HidePooledObject : MonoBehaviour, IPooledObject
{
    public void OnObjectHide() { Debug.Log("Hide Object Called:", this); gameObject.SetActive(false); }
    public void OnObjectSpawned() { }
}
