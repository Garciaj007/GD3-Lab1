using UnityEngine;

public class RandomIrisSize : MonoBehaviour
{
    [SerializeField] private Vector2 irisMinMaxSize = new Vector2(0.5f, 0.8f);

    void Start()
    {
        var size = Random.Range(irisMinMaxSize.x, irisMinMaxSize.y);
        transform.localScale = new Vector3(size, size, 1.0f);
    }
}
