using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
class EntityComponent : MonoBehaviour {

    [SerializeField] private Entity entity = null;

    private HealthComponent healthComponent = null;

    public Entity Entity { get { return entity; } }

    private void Awake() {
        name = entity.name;
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.SetMaxHealth(entity.maxHealth);
    }

    private void Update() {

    }
}
