using UnityEngine;

public class Scaler2D : MonoBehaviour
{
    [SerializeField] private Vector2 speed = new Vector2(1,1);

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(speed.x * Time.deltaTime, speed.y * Time.deltaTime, 1);
    }
}
