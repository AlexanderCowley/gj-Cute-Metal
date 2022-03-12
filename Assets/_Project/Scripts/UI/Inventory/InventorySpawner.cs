using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySpawner : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    void TurnOnCanvas() => canvas.enabled = true;
}