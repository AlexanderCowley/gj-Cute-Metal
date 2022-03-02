using UnityEngine;

[CreateAssetMenu(menuName = "New Character")]
public class CharacterStats : ScriptableObject
{
    [Header("Character Health")]
    [SerializeField] int maxHealth = 10;
    int health;
    [Header("Character Speed")]
    [SerializeField] float speed = 1;

    public float Speed => speed;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            health = Mathf.Clamp(health, 0, maxHealth);
        }
    }

    void OnEnable() => Health = maxHealth;
}