﻿using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
class EntityComponent : MonoBehaviour {

    [SerializeField] private Entity entity = null;

    private HealthComponent healthComponent = null;

    public Entity Entity { get { return entity; } }

    private void Awake() {
        healthComponent = GetComponent<HealthComponent>();
    }

    private void Start() {
        name = entity.name;
        healthComponent.SetMaxHealth(entity.MaxHealth);
    }

    private void Update() {

    }
}