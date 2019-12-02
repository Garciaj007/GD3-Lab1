using UnityEngine;

public class TargetMoveBehaviour : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(0, 0, -GameManager.Instance.TargetSpeed * Time.deltaTime);
    }
}
