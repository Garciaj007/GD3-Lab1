using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void Trigger2DEnterDelegate(Collider2D info);
    public event Trigger2DEnterDelegate OnTrigger2DEnter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        OnTrigger2DEnter?.Invoke(col);
    }
}
