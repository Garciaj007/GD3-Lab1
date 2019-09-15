using UnityEngine;

public class BlockCollisionDetect : MonoBehaviour
{
    public delegate void OnBlockTriggerDelegate();
    public static event OnBlockTriggerDelegate blockCollisionDelegate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Debug.Log(collision.gameObject.name);
            blockCollisionDelegate?.Invoke();
        }
    }
}
