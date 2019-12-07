using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorBehaviour : MonoBehaviour
{
    public static MouseCursorBehaviour Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this);
        Instance = this;
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
