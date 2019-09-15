using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    public float DestroyDelay { private get; set; }

    // Update is called once per frame
    private void Update()
    {
        Destroy(gameObject, DestroyDelay);
    }

    private void OnDestroy()
    {
        BlockManager.Instance.Blocks.Remove(gameObject);
    }
}
