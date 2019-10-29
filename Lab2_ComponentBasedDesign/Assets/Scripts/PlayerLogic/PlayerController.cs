using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnNewPositionClickDelegate (Vector3 mousePos);
    public event OnNewPositionClickDelegate NewPositionClick;

    private void Awake()
    {
        GameManager.Instance.Players.Add(this);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        NewPositionClick?.Invoke(mousePosition);
    }
}
