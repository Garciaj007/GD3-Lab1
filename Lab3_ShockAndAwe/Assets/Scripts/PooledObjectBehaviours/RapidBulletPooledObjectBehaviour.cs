using UnityEngine;

public class RapidBulletPooledObjectBehaviour : MonoBehaviour, IPooledObject
{
    public void OnObjectHide()
    {
        //GetComponent<TrailRenderer>().Clear(); 
    }
    public void OnObjectSpawned()
    {
        GetComponent<TrailRenderer>().Clear(); 
    }

    [SerializeField] private float bulletSpeed = 10.0f;
    public void Update()
    {
        transform.position += new Vector3(0, 0, bulletSpeed * Time.deltaTime);
    }
}
