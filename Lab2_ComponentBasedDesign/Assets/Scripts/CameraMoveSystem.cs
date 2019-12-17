using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveSystem : MonoBehaviour
{
    [SerializeField] private Vector2 cameraBounds = Vector2.zero;
    [SerializeField] private float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > cameraBounds.x)
            transform.position = new Vector3(-cameraBounds.x + 1.0f, transform.position.y, transform.position.z);

        if(transform.position.x < -cameraBounds.x)
            transform.position = new Vector3(cameraBounds.x - 1.0f, transform.position.y, transform.position.z);

        if(transform.position.y > cameraBounds.y)
            transform.position = new Vector3(-cameraBounds.y + 1.0f, transform.position.y, transform.position.z);

        if(transform.position.y < -cameraBounds.y)
            transform.position = new Vector3(cameraBounds.y - 1.0f, transform.position.y, transform.position.z);     

        var mouseViewportSpace = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x ,Input.mousePosition.y, Camera.main.nearClipPlane)) * 2;
        var mousePosition = new Vector2(mouseViewportSpace.x - 1.0f, mouseViewportSpace.y - 1.0f);

        if(mousePosition.x < -0.7f)
            transform.position += Vector3.left * Time.deltaTime * speed;

        if(mousePosition.x > 0.7f)
            transform.position += Vector3.right * Time.deltaTime * speed;

        if(mousePosition.y > 0.7f)
            transform.position += Vector3.up * Time.deltaTime * speed;

        if(mousePosition.y < -0.7f)
            transform.position += Vector3.down * Time.deltaTime * speed;
    }
}
