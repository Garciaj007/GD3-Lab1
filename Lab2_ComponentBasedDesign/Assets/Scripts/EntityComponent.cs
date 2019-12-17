using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
class EntityComponent : MonoBehaviour {

    [SerializeField] private Entity entity = null;
    [SerializeField] private bool locked = false;

    private bool inDefense = true;
    private HealthComponent healthComponent = null;

    public bool IsLocked => locked;
    public bool CanMove => !inDefense && !locked;
    public bool InDefense => inDefense;
    public void Move() => inDefense = false;
    public void Defend() => inDefense = true;

    public Entity Entity => entity;

    private void Awake() {
        name = entity.name;
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.SetMaxHealth(entity.maxHealth);
        healthComponent.SetHealth(entity.maxHealth);
    }
}
