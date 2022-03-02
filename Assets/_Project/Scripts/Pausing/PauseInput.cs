using UnityEngine;

public class PauseInput : MonoBehaviour
{
    [SerializeField] PauseData pauseData;
    [SerializeField] CharacterInventory inventory;
    Canvas _itemInventory;
    void TogglePause() => pauseData.IsPaused = !pauseData.IsPaused;

    void OnEnable()
    {
        _itemInventory = GetComponentInChildren<Canvas>();
        pauseData.PauseEventHandler += ToggleCanvasComponent;
    }

    void OnDisable() => pauseData.PauseEventHandler -= ToggleCanvasComponent;

    void ToggleCanvasComponent() => _itemInventory.enabled = pauseData.IsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
}