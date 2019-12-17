using UnityEngine;

public class ApplyEntitySprite : MonoBehaviour
{
    [SerializeField] private bool applyCollider = true;
    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<EntityComponent>().Entity.sprite;
        if(applyCollider)
            GetComponent<PolygonCollider2D>().SetPath(0, GetComponent<EntityComponent>().Entity.sprite.vertices);
    }
}
