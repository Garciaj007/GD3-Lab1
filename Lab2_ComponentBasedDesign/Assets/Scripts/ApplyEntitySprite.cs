using UnityEngine;

public class ApplyEntitySprite : MonoBehaviour
{
    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<EntityComponent>().Entity.sprite;
        GetComponent<PolygonCollider2D>().SetPath(0, GetComponent<EntityComponent>().Entity.sprite.vertices);
    }
}
