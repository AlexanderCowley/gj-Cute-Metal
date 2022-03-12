using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(OnDamageTaken))]
public class OnPlayerDeath : MonoBehaviour
{
    OnDamageTaken damagable;
    void Awake() => damagable = GetComponent<OnDamageTaken>();
    void OnEnable() => damagable.Stats.playerDeathHandler += ResetScene;
    void OnDisable() => damagable.Stats.playerDeathHandler -= ResetScene;
    void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}