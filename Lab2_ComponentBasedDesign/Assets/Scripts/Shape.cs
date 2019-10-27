using UnityEngine;

[System.Serializable]
public class Shape : MonoBehaviour
{
    [SerializeField] protected Mesh mesh = null;
    [SerializeField] protected Vector3[] vertices = null;
    [SerializeField] protected int[] indices = null;

    protected PolygonCollider2D polyCollider = null;

    public int VertexCount => indices.Length;

    public Vector3[] Vertices
    {
        get => vertices;
        set => vertices = value;
    }

    protected void Awake()
    {
        if (indices == null) return;

        mesh = new Mesh();
        vertices = new Vector3[3];
        GetComponent<MeshFilter>().mesh = mesh;
        polyCollider = GetComponent<PolygonCollider2D>();
    }

    protected void Start()
    {
        if (indices == null) return;

        PopulateVertices();
        UpdateMesh();
        UpdateCollisionPath();
    }

    protected void LateUpdate()
    {
        if (indices == null) return;
        UpdateMesh();
        UpdateCollisionPath();
    }

    protected void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = indices;
        mesh.RecalculateNormals();
    }

    protected void UpdateCollisionPath()
    {
        var points = new Vector2[VertexCount];
        for (var i = 0; i < VertexCount; i++)
        {
            points[i] = vertices[i];
        }
        polyCollider.SetPath(0, points);
    }

    protected void PopulateVertices()
    {
        for (int v = 0; v < indices.Length; v++)
        {
            vertices[v] = GenerateUnitVector();
        }
    }

    protected Vector3 GenerateUnitVector()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
