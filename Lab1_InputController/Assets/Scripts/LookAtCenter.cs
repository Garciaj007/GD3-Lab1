using UnityEngine;
public class LookAtCenter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var direction = -transform.position.normalized;
        var lookAt = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, lookAt - 90);
    }
}
