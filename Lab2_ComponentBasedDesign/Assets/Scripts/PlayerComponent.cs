using UnityEngine;

[CreateAssetMenu(fileName ="Data", menuName = "ScriptableObjects/SpawnPlayer", order = 1)]
class PlayerEntity : ScriptableObject
{
    [Header("Attributes")]
    public string name;
    public Sprite sprite;
    public float movementSpeed;
    public float attackRate;
    public float attackDamage;
    public float MaxHealth;
    public float MaxRotateAngle;

    [Header("SFX")]
    public float rotationAmount;
    public AnimationCurve curve;
}

[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(SpriteRenderer))]
class PlayerComponent : MonoBehaviour
{
    [SerializeField] private PlayerEntity sciptable = null;
    private SpriteRenderer sp = null;
    private HealthComponent healthComponent = null;

    public PlayerEntity Sciptable { get => sciptable; private set => sciptable = value; }

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        healthComponent = GetComponent<HealthComponent>();
    }
  
    private void Start()
    {
        sp.sprite = sciptable.sprite;
        name = sciptable.name;
        healthComponent.SetMaxHealth(sciptable.MaxHealth);
    }

    private void Update()
    {
        
    }

    private void OnMouseOver()
    {
        float h, s, v;
        Color.RGBToHSV(sp.color, out h, out s, out v);
        sp.color = Color.HSVToRGB(h, s, 1f);
    }

    private void OnMouseDown()
    {
        
    }
}
