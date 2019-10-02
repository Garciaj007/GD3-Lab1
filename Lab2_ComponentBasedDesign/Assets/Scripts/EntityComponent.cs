using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnPlayer", order = 1)]
class Entity : ScriptableObject {
    [Header("Attributes")]
    public string name;
    public Sprite sprite;
    public float movementSpeed;
    public float attackRate;
    public float attackDamage;
    public float MaxHealth;

    [Header("SFX")]
    public float rotationAmount;
    public AnimationCurve curve;
}

[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(SpriteRenderer))]
class EntityComponent : MonoBehaviour {

    [SerializeField] private Entity sciptable = null;
    private SpriteRenderer sp = null;
    private HealthComponent healthComponent = null;

    private void Awake() {
        sp = GetComponent<SpriteRenderer>();
        healthComponent = GetComponent<HealthComponent>();
    }

    private void Start() {
        sp.sprite = sciptable.sprite;
        name = sciptable.name;
        healthComponent.SetMaxHealth(sciptable.MaxHealth);
    }

    private void Update() {

    }
}
