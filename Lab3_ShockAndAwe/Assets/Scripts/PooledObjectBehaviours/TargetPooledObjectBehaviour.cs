using UnityEngine;

public class TargetPooledObjectBehaviour : MonoBehaviour, IPooledObject
{
    public void OnObjectHide(){gameObject.SetActive(false);}

    public void OnObjectSpawned(){}

    private void Update()
    {
        transform.position += new Vector3(0, 0, -GameManager.Instance.TargetSpeed * Time.deltaTime);
    }
}
