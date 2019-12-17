using UnityEngine;

public class RapidBulletPooledObjectBehaviour : MonoBehaviour, IPooledObject
{

    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private AudioClip clip = null;
    public void OnObjectHide() { gameObject.SetActive(false); }

    public void OnObjectSpawned(){ GetComponent<AudioSource>().PlayOneShot(clip); }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Target"))
        {
            other.gameObject.GetComponent<IPooledObject>()?.OnObjectHide();
            GetComponent<IPooledObject>()?.OnObjectHide();
        }
    }

    public void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}
