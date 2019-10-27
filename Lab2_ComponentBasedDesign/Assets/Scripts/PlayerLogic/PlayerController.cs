using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnNewPositionClickDelegate (Vector3 mousePos);
    public event OnNewPositionClickDelegate NewPositionClick;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        NewPositionClick?.Invoke(mousePosition);
    }
}
