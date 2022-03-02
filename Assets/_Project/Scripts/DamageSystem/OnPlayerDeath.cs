using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPlayerDeath : MonoBehaviour, IDamagable
{
    public void OnTakeDamage()
    {
        ResetScene();
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}