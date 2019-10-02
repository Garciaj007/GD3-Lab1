using UnityEngine;

[CreateAssetMenu(fileName = "EntityScriptable", menuName = "ScriptableObjects/Entity", order = 1)]
class Entity : ScriptableObject
{
    [Header("Attributes")]
    public Sprite sprite;
    public float movementSpeed;
    public float attackRate;
    public float attackDamage;
    public float MaxHealth;

    [Header("SFX")]
    public float rotationAmount;
    public AnimationCurve curve;
}