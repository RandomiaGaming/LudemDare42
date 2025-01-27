using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int startingHeartContainers = 2;
    public int startingHealth = 1;
    public bool destroyOnKill = true;
    public float invincibilityDuration = 0;
    [Space]
    public UnityEvent onHeal;
    public UnityEvent onDamage;
    public UnityEvent onKill;

    private int currentHealth = 1;
    private int currentHeartContainers = 2;
    private float invincibilityTimer = 0;
    private void Start()
    {
        currentHealth = startingHealth;
        currentHeartContainers = startingHeartContainers;
    }
    private void Update()
    {
        invincibilityTimer -= Time.deltaTime;
        invincibilityTimer = Mathf.Clamp(invincibilityTimer, 0, float.MaxValue);
    }
    public int GetHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, currentHeartContainers * 2);
        return currentHealth;
    }
    public int GetHeartContainers()
    {
        currentHeartContainers = Mathf.Clamp(currentHeartContainers, 0, int.MaxValue);
        return currentHeartContainers;
    }
    public void Damage(int damageAmount)
    {
        if (invincibilityTimer > 0)
        {
            return;
        }
        if (currentHealth <= 0)
        {
            //The character is already dead so return.
            return;
        }
        if (damageAmount <= 0)
        {
            //The damage amount must be a positive non zero integer.
            return;
        }
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, currentHeartContainers * 2);
        onDamage.Invoke();
        if (currentHealth <= 0)
        {
            onKill.Invoke();
            if (destroyOnKill)
            {
                Destroy(gameObject);
            }
        }
        invincibilityTimer = invincibilityDuration;
    }
    public void Heal(int healAmount)
    {
        if (currentHealth <= 0)
        {
            //The character is already dead so return.
            return;
        }
        if (healAmount <= 0)
        {
            //The damage amount must be a positive non zero integer.
            return;
        }
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, currentHeartContainers * 2);
        onHeal.Invoke();
    }
}