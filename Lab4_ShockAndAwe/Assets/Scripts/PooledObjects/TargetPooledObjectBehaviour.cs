using UnityEngine;

public class TargetPooledObjectBehaviour : MonoBehaviour, IPooledObject
{
    private Color spawnColor = Color.white;

    public void OnObjectHide(){ gameObject.SetActive(false); }

    public void OnObjectSpawned(){ GetComponent<MeshRenderer>().material.color = spawnColor; }

    private void Start()
    {
        spawnColor = GetComponent<MeshRenderer>().material.color;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, -GameManager.Instance.TargetSpeed * Time.deltaTime * BeatScalar.Instance.Scalar);
    }
}
