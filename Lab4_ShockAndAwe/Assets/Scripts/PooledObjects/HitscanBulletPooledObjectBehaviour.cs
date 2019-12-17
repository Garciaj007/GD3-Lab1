using UnityEngine;

public class HitscanBulletPooledObjectBehaviour : MonoBehaviour, IPooledObject
{
    public GameObject Target { get; set; }

    [SerializeField] private AudioClip clip = null; 
    [SerializeField] private float bulletMaxSpeed = 10.0f;

    public void OnObjectHide()
    {
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Target)
        {
            other.gameObject.GetComponent<IPooledObject>()?.OnObjectHide();
            GetComponent<IPooledObject>()?.OnObjectHide();
        }
    }

    public void OnObjectSpawned()
    {
        GetComponent<TrailRenderer>().Clear();
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    private void Update()
    {
        var desired = (Target.transform.position - transform.position).normalized;
        desired *= bulletMaxSpeed;
        GetComponent<Rigidbody>().velocity = desired;
    }
}
