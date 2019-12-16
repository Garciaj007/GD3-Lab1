using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    private bool isActive = false;

    public EntityScriptableObject Entity{ get; private set; }

    public void Create(EntityScriptableObject entity)
    {
        this.Entity = entity;
        isActive = true;
    }

    void Update()
    {
        if(!isActive) return;
        if(Entity.hp < 0) GameManager.I.DestroyEntity(this);
    }
}
