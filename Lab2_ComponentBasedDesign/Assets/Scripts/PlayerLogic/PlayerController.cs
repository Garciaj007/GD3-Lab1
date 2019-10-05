using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void Trigger2DDelegate(Collider2D info);
    public event Trigger2DDelegate OnTrigger2DStay;

    public delegate void MouseDownPosDelegate(Vector3 pos);
    public event MouseDownPosDelegate OnMouseDownPos;

    public float Speed;
    public float AttackCoolDown;

    internal Vector3 moveToPos;

    internal int targetsInRange;

    // Start is called before the first frame update
    void Start()
    {
        moveToPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Temp code
        if (Input.GetMouseButtonDown(2))
        {
            var temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.z = 0f;

            OnMouseDownPos?.Invoke(temp);
        }
    }

    public void Attack()
    {
        Debug.Log("Player attacking!");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyUnit")
        {
            targetsInRange++;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        OnTrigger2DStay?.Invoke(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "EnemyUnit")
        {
            targetsInRange--;
        }
    }
}
