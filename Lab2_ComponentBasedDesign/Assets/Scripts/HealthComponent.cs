using UnityEngine;

public class HealthComponent : MonoBehaviour 
{
    public delegate void OnDeathDelegate();
    public static event OnDeathDelegate deathDelegate;

    [SerializeField] private float health = 0f;
    [SerializeField] private float maxHealth = 1f;
    
    private void Update()
    {
        if (health <= 0f && deathDelegate != null)
        {
            health = 0f;
            deathDelegate();
        }
    }

    public void Damage(float amount) => health -= amount;

    public void Heal(float amount)
    {
        var newHeath = health + amount;
        health = newHeath > maxHealth ? maxHealth : newHeath;
    }


    public float GetHealthPercent() { return health / maxHealth; }
    public float GetHealth() { return health; }
    public void SetHealth(float health_) => health = health_;
    public float GetMaxHealth() { return health; }
    public void SetMaxHealth(float maxHealth_) => maxHealth = maxHealth_;
}
