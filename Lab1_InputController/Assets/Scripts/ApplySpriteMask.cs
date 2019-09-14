using UnityEngine;
public class ApplySpriteMask : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }
}
