using UnityEngine;

public class ShapeRandomAnimator : MonoBehaviour
{
    [SerializeField] protected Shape shape = null;
    [SerializeField] protected float animationSpeed = 0.1f;
    [SerializeField] protected float shapeScale = 4.0f;

    protected float time = 0.0f;

    protected void Start()
    {
        shape = GetComponent<Shape>();
        time = Random.Range(0f, 10.0f);
    }

    protected void Update()
    {
        UpdateTime();

        for(int i = 0; i < shape.VertexCount; i++)
        {
            shape.Vertices[i] = GetNextVertexPosition(i);
        }
    }

    protected void UpdateTime()
    {
        time += Time.deltaTime * animationSpeed * Mathf.Pow(BeatScalar.Instance.Scalar, 10);
    }

    protected Vector3 GetNextVertexPosition(int index)
    {
        return new Vector3(GetNextPerlinValue(index), GetNextPerlinValue(index + 1.0f));
    }

    protected float GetNextPerlinValue(float vertexIndex)
    {
        return (Mathf.PerlinNoise(time + vertexIndex, 0.0f) * 2 - 1) * shapeScale;
    }
}
