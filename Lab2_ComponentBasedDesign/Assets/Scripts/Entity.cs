using UnityEngine;

[CreateAssetMenu(fileName = "EntityScriptable", menuName = "ScriptableObjects/Entity", order = 1)]
class Entity : ScriptableObject
{
    [Header("Attributes")]
    public AnimationCurve curve;
    public Sprite sprite;
    public float arrivingDistance;
    public float maxSpeed;
    public float maxForce;
    public float attackRate;
    public float attackDamage;
    public float maxHealth;
}