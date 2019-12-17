using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private float startingHp = 10.0f;
    [SerializeField] private int likesAddedWhenDead = 10;

    private float hp = Mathf.Infinity;
    
    public int LikesAddedWhenDead { get => likesAddedWhenDead; }
    public float HP { get => hp / startingHp; }

    private void Start()
    {
        startingHp *= GameManager.I.Difficulty;
        hp = startingHp;
        MouseEventHandlerManager.mouseDownEvent += DecrementHp;
    }

    private void Update()
    {
        if(hp < 0) GameManager.I.DestroyEntity(this);
    }

    private void DecrementHp()
    { 
        hp -= GameManager.I.Damage;
        GameManager.I.RefreshEntityUI(this);
    }
}   
