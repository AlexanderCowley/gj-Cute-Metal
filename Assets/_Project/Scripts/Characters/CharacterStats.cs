using UnityEngine;

[CreateAssetMenu(menuName = "New Character")]
public class CharacterStats : ScriptableObject
{
    [Header("Character Health")]
    [SerializeField] int maxHealth = 10;
    [SerializeField, ReadOnly] int currentHealth;
    [Header("Character Speed")]
    [SerializeField] float speed = 1;

    public delegate void OnDeath();
    public event OnDeath playerDeathHandler;

    public float Speed => speed;

    public int Health
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            if (currentHealth <= 0)
                playerDeathHandler?.Invoke();
        }
    }

    void OnEnable() => Health = maxHealth;
}