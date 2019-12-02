using UnityEngine;

public class RapidBulletBehaviour : MonoBehaviour
{
    public void Update()
    {
        transform.position += new Vector3(0,0, 1 * Time.deltaTime);
    }
}
