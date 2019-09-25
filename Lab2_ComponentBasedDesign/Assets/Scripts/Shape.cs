using UnityEngine;

[System.Serializable]
public class Shape : MonoBehaviour
{
    [SerializeField] protected Mesh mesh = null;
    [SerializeField] protected Vector3[] verticies = null;
    [SerializeField] protected int[] indicies = null;

    protected PolygonCollider2D polyCollider = null;

    public int VertexCount
    {
        get
        {
            return indicies.Length;
        }
    }

    public Vector3[] Verticies
    {
        get
        {
            return verticies;
        }

        set
        {
            verticies = value;
        }
    }

    protected void Awake()
    {
        if (indicies == null) return;

        mesh = new Mesh();
        verticies = new Vector3[3];
        GetComponent<MeshFilter>().mesh = mesh;
        polyCollider = GetComponent<PolygonCollider2D>();
    }

    protected void Start()
    {
        if (indicies == null) return;

        PopulateVerticies();
        UpdateMesh();
        UpdateCollisionPath();
    }

    protected void LateUpdate()
    {
        if (indicies == null) return;
        UpdateMesh();
        UpdateCollisionPath();
    }

    protected void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = indicies;
        mesh.RecalculateNormals();
    }

    protected void UpdateCollisionPath()
    {
        var points = new Vector2[VertexCount];
        for (var i = 0; i < VertexCount; i++)
        {
            points[i] = verticies[i];
        }
        polyCollider.SetPath(0, points);
    }

    protected void PopulateVerticies()
    {
        for (int v = 0; v < indicies.Length; v++)
        {
            verticies[v] = GenerateUnitVector();
        }
    }

    protected Vector3 GenerateUnitVector()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}

