using UnityEngine;
using System.Collections.Generic;

public class ApplyEntitySprite : MonoBehaviour
{
    [SerializeField] private bool applyCollider = true;
    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<EntityComponent>().Entity.sprite;

        if (applyCollider)
        {
            var path = new List<Vector2>();
            GetComponent<SpriteRenderer>().sprite.GetPhysicsShape(0, path);
            GetComponent<PolygonCollider2D>().SetPath(0, path.ToArray());
        }
    }
}
