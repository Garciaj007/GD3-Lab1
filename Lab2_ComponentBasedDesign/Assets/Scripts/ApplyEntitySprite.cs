using UnityEngine;

public class ApplyEntitySprite : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = 
            GetComponent<EntityComponent>().Entity.sprite;
    }
}
