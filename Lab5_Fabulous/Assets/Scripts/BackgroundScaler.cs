using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{

    [SerializeField] private Camera orthoCamera = null;

    void Start()
    {
        var sp = GetComponent<SpriteRenderer>();
        var dimensions = Utils.ScreenSize.GetScreenToWorld(sp.sprite.bounds.extents.x, sp.sprite.bounds.extents.y, orthoCamera);
        transform.localScale = new Vector3(dimensions.x, dimensions.y, 1.0f);
    }
}
