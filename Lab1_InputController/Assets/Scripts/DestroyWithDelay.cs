using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 5.0f;

    // Update is called once per frame
    private void Update()
    {
        Destroy(gameObject, destroyDelay);
    }
}
