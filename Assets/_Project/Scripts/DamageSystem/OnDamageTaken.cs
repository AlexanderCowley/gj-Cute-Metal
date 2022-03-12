using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDamageTaken : MonoBehaviour, IDamagable
{
    [SerializeField] CharacterStats stats;
    public CharacterStats Stats => stats;
    public void OnTakeDamage(int damageTaken)
    {
        print("Damage Taken: " + damageTaken);
        stats.Health -= damageTaken;
    }
}